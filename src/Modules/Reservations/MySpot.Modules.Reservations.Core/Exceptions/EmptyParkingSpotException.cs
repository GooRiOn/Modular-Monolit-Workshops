using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Reservations.Core.Exceptions;

public class EmptyParkingSpotException : CustomException
{
    public EmptyParkingSpotException() : base("Parking spot name cannot be empty.")
    {
    }
}