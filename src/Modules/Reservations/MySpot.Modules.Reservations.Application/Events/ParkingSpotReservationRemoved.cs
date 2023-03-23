using MySpot.Shared.Abstractions.Events;

namespace MySpot.Modules.Reservations.Application.Events;

public record ParkingSpotReservationRemoved(Guid ReservationId, Guid ParkingSpotId, DateTimeOffset Date) : IEvent;