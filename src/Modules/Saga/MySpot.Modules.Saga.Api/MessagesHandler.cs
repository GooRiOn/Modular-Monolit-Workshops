using System.Threading;
using System.Threading.Tasks;
using Chronicle;
using MySpot.Modules.Saga.Api.Messages;
using MySpot.Shared.Abstractions.Events;

namespace MySpot.Modules.Saga.Api;

internal sealed class MessagesHandler :
    IEventHandler<ParkingSpotReserved>,
    IEventHandler<ResourceReserved>
{
    private readonly ISagaCoordinator _sagaCoordinator;

    public MessagesHandler(ISagaCoordinator sagaCoordinator)
    {
        _sagaCoordinator = sagaCoordinator;
    }

    public Task HandleAsync(ParkingSpotReserved @event, CancellationToken cancellationToken = default)
        => ProcessAsync(@event);

    public Task HandleAsync(ResourceReserved @event, CancellationToken cancellationToken = default)
        => ProcessAsync(@event);

    private Task ProcessAsync<T>(T message) where T : class =>
        _sagaCoordinator.ProcessAsync(message, SagaContext.Empty);
}