using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MySpot.Shared.Abstractions.Messaging;

namespace MySpot.Shared.Infrastructure.Messaging.Outbox;

public class OutboxBroker : IOutboxBroker
{
    private readonly IServiceProvider _serviceProvider;
    private readonly OutboxTypeRegistry _registry;

    public OutboxBroker(IServiceProvider serviceProvider, OutboxTypeRegistry registry, IOptions<OutboxOptions> options)
    {
        _serviceProvider = serviceProvider;
        _registry = registry;
        Enabled = options.Value.Enabled;
    }

    public bool Enabled { get; }

    public async Task SendAsync(params IMessage[] messages)
    {
        var message = messages[0]; // Not possible to send messages from different modules at once
        var outboxType = _registry.Resolve(message);
        if (outboxType is null)
        {
            throw new InvalidOperationException($"Outbox is not registered for module: '{message.GetModuleName()}'.");
        }

        using var scope = _serviceProvider.CreateScope();
        var outbox = (IOutbox)scope.ServiceProvider.GetRequiredService(outboxType);
        await outbox.SaveAsync(messages);
    }
}