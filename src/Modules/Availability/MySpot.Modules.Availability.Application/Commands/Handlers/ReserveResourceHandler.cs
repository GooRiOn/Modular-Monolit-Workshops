using System.Threading;
using System.Threading.Tasks;
using MySpot.Modules.Availability.Application.Events;
using MySpot.Modules.Availability.Application.Exceptions;
using MySpot.Modules.Availability.Core.Entities;
using MySpot.Modules.Availability.Core.Repositories;
using MySpot.Modules.Availability.Core.ValueObjects;
using MySpot.Shared.Abstractions.Commands;
using MySpot.Shared.Abstractions.Messaging;

namespace MySpot.Modules.Availability.Application.Commands.Handlers;

internal sealed class ReserveResourceHandler : ICommandHandler<ReserveResource>
{
    private readonly IResourcesRepository _repository;
    private readonly IMessageBroker _messageBroker;

    public ReserveResourceHandler(IResourcesRepository repository, IMessageBroker messageBroker)
    {
        _repository = repository;
        _messageBroker = messageBroker;
    }

    public async Task HandleAsync(ReserveResource command, CancellationToken cancellationToken = default)
    {
        var (resourceId, reservationId, capacity, date, priority) = command;
        var resource = await _repository.GetAsync(resourceId);
        if (resource is null)
        {
            throw new ResourceNotFoundException(resourceId);
        }

        var reservation = new Reservation(reservationId, capacity, new Date(date), priority);
        resource.AddReservation(reservation);
        await _repository.UpdateAsync(resource);
        await _messageBroker.PublishAsync(new ResourceReserved(resourceId, date), cancellationToken);
    }
}