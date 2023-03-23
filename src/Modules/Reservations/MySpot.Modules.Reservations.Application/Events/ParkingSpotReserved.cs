using MySpot.Shared.Abstractions.Events;

namespace MySpot.Modules.Reservations.Application.Events;

public record ParkingSpotReserved(Guid ReservationId, Guid ParkingSpotId, Guid UserId, DateTimeOffset Date) : IEvent;