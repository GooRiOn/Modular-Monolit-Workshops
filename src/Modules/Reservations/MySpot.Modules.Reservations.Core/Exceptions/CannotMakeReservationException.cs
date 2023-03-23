using MySpot.Modules.Reservations.Core.Types;
using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Reservations.Core.Exceptions;

public sealed class CannotMakeReservationException : CustomException
{
    public ParkingSpotId ParkingSpotId { get; }

    public CannotMakeReservationException(ParkingSpotId parkingSpotId) 
        : base($"Cannot reserve parking spot with ID: {parkingSpotId} due to reservation policy.")
    {
        ParkingSpotId = parkingSpotId;
    }
}