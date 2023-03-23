using System;
using MySpot.Shared.Abstractions.Commands;

namespace MySpot.Modules.Availability.Application.Commands;

public record ReserveResource(Guid ResourceId, Guid ReservationId, int Capacity, DateTimeOffset Date, int Priority) : ICommand;