using MySpot.Modules.Reservations.Core.Types;
using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Reservations.Core.Exceptions;

public sealed class ReservationNotFoundException : CustomException
{
    public ReservationId ReservationId { get; }

    public ReservationNotFoundException(ReservationId reservationId) 
        : base($"Couldn't find reservation with ID: {reservationId}")
    {
        ReservationId = reservationId;
    }
}