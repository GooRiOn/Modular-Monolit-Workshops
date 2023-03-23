using System;
using MySpot.Shared.Abstractions.Commands;

namespace MySpot.Modules.Availability.Application.Commands;

public record ReleaseResourceReservation(Guid ResourceId, DateTimeOffset Date) : ICommand;