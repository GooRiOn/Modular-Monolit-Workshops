using MySpot.Modules.Reservations.Core.ValueObjects;
using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Reservations.Core.Exceptions;

internal sealed class InvalidReservationDateException : CustomException
{
    public DateTimeOffset Date { get; }

    public InvalidReservationDateException(Date date) : base($"Reservation date is invalid: {date}.")
    {
        Date = date;
    }
}