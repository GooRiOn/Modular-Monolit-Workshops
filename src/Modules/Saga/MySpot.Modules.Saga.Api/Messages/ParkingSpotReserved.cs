using System;
using MySpot.Shared.Abstractions.Events;

namespace MySpot.Modules.Saga.Api.Messages;

public record ParkingSpotReserved(Guid ReservationId, Guid ParkingSpotId, Guid UserId, DateTimeOffset Date) : IEvent;