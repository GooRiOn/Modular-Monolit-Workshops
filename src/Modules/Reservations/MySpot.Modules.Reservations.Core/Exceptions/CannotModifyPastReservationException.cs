using MySpot.Modules.Reservations.Core.ValueObjects;
using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Reservations.Core.Exceptions;

public sealed class CannotModifyPastReservationException : CustomException
{
    public Date Date { get; }

    public CannotModifyPastReservationException(Date date) 
        : base($"Cannot modify reservation with date: {date} which is past.")
    {
        Date = date;
    }
}