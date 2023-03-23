using System;
using MySpot.Shared.Abstractions.Events;

namespace MySpot.Modules.Availability.Application.Events;

public record ResourceAdded(Guid ResourceId) : IEvent;