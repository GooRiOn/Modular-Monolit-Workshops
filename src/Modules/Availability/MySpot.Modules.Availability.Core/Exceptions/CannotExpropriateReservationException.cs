using System;
using MySpot.Modules.Availability.Core.ValueObjects;
using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Availability.Core.Exceptions;

public class CannotExpropriateReservationException : CustomException
{
    public Guid ResourceId { get; }
    public Date Date { get; }

    public CannotExpropriateReservationException(Guid resourceId, Date dateTime)
        : base($"Cannot expropriate resource {resourceId} reservation at {dateTime}")
        => (ResourceId, Date) = (resourceId, dateTime);
}