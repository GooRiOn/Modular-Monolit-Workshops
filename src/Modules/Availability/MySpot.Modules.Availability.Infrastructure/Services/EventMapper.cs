using System.Collections.Generic;
using System.Linq;
using MySpot.Modules.Availability.Application.Events;
using MySpot.Modules.Availability.Core.Events;
using MySpot.Shared.Abstractions.Domain;
using MySpot.Shared.Abstractions.Events;
using ResourceDeleted = MySpot.Modules.Availability.Core.Events.ResourceDeleted;

namespace MySpot.Modules.Availability.Infrastructure.Services;

internal sealed class EventMapper
{
    public IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> events)
        => events.Select(Map);

    public IEvent Map(IDomainEvent @event)
        => @event switch
        {
            ResourceCreated e => new ResourceAdded(e.Resource.Id),
            ResourceDeleted e => new MySpot.Modules.Availability.Application.Events.ResourceDeleted(e.Resource.Id),
            ReservationAdded e => new ResourceReserved(e.Resource.Id, e.Reservation.Date.Value),
            ReservationReleased e => new ResourceReservationReleased(e.Resource.Id, e.Reservation.Date),
            ReservationCanceled e => new ResourceReservationCanceled(e.Resource.Id, e.Reservation.Date),
            _ => null
        };
}