using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MySpot.Shared.Abstractions.Time;

namespace MySpot.Shared.Infrastructure.Messaging.Outbox;

public class OutboxCleanupProcessor : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly IClock _clock;
    private readonly ILogger<OutboxCleanupProcessor> _logger;
    private readonly TimeSpan _interval;
    private readonly bool _enabled;
    private readonly TimeSpan _startDelay;
    private int _isProcessing;

    public OutboxCleanupProcessor(IServiceScopeFactory serviceScopeFactory, IOptions<OutboxOptions> outboxOptions,
        IClock clock, ILogger<OutboxCleanupProcessor> logger)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _clock = clock;
        _logger = logger;
        _enabled = outboxOptions.Value.Enabled;
        _interval = outboxOptions.Value.OutboxCleanupInterval ?? TimeSpan.FromHours(1);
        _startDelay = outboxOptions.Value.StartDelay ?? TimeSpan.FromSeconds(5);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (!_enabled)
        {
            return;
        }

        await Task.Delay(_startDelay, stoppingToken);
        while (!stoppingToken.IsCancellationRequested)
        {
            if (Interlocked.Exchange(ref _isProcessing, 1) == 1)
            {
                await Task.Delay(_interval, stoppingToken);
                continue;
            }

            _logger.LogTrace("Started cleaning up outbox messages...");
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                try
                {
                    var outboxes = scope.ServiceProvider.GetServices<IOutbox>();
                    var tasks = outboxes.Select(outbox => outbox.CleanupAsync(_clock.CurrentDate().Subtract(_interval)));
                    await Task.WhenAll(tasks);
                }
                catch (Exception exception)
                {
                    _logger.LogError("There was an error when processing outbox.");
                    _logger.LogError(exception, exception.Message);
                }
                finally
                {
                    Interlocked.Exchange(ref _isProcessing, 0);
                    stopwatch.Stop();
                    _logger.LogTrace($"Finished cleaning up outbox messages in {stopwatch.ElapsedMilliseconds} ms.");
                }
            }

            await Task.Delay(_interval, stoppingToken);
        }
    }
}