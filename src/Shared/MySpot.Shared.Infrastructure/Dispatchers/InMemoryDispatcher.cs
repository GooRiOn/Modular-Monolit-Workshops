using System.Threading;
using System.Threading.Tasks;
using MySpot.Shared.Abstractions.Commands;
using MySpot.Shared.Abstractions.Dispatchers;
using MySpot.Shared.Abstractions.Events;
using MySpot.Shared.Abstractions.Queries;

namespace MySpot.Shared.Infrastructure.Dispatchers;

public class InMemoryDispatcher : IDispatcher
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IEventDispatcher _eventDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public InMemoryDispatcher(ICommandDispatcher commandDispatcher, IEventDispatcher eventDispatcher,
        IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _eventDispatcher = eventDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    public Task SendAsync<T>(T command, CancellationToken cancellationToken = default) where T : class, ICommand
        => _commandDispatcher.SendAsync(command, cancellationToken);

    public Task PublishAsync<T>(T @event, CancellationToken cancellationToken = default) where T : class, IEvent
        => _eventDispatcher.PublishAsync(@event, cancellationToken);

    public Task<TResult> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
        => _queryDispatcher.QueryAsync(query, cancellationToken);
}