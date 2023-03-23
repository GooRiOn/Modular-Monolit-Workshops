using System;
using MySpot.Shared.Abstractions.Events;

namespace MySpot.Modules.Availability.Application.Events;

public record ResourceReservationReleased(Guid ResourceId, DateTimeOffset Date) : IEvent;