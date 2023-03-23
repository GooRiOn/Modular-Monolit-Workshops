using MySpot.Modules.Reservations.Core.Types;
using MySpot.Modules.Reservations.Core.ValueObjects;
using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Reservations.Core.Exceptions;

public sealed class InvalidWeeklyParkingSpotDatesException : CustomException
{
    public InvalidWeeklyParkingSpotDatesException(ParkingSpotId parkingSpotId, Date from, Date to) 
        : base($"Parking spot with ID: {parkingSpotId} cannot define hours from {from} to {to}")
    {
    }
}