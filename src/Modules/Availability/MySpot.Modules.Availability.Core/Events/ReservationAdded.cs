using MySpot.Modules.Availability.Core.Entities;
using MySpot.Shared.Abstractions.Domain;

namespace MySpot.Modules.Availability.Core.Events;

public class ReservationAdded : IDomainEvent
{
    public Resource Resource { get; }
    public Reservation Reservation { get; }

    public ReservationAdded(Resource resource, Reservation reservation)
        => (Resource, Reservation) = (resource, reservation);
}