using System.Threading;
using System.Threading.Tasks;
using MySpot.Shared.Abstractions.Commands;
using MySpot.Shared.Abstractions.Events;
using MySpot.Shared.Abstractions.Queries;

namespace MySpot.Shared.Abstractions.Dispatchers;

public interface IDispatcher
{
    Task SendAsync<T>(T command, CancellationToken cancellationToken = default) where T : class, ICommand;
    Task PublishAsync<T>(T @event, CancellationToken cancellationToken = default) where T : class, IEvent;
    Task<TResult> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
}