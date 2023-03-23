using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.ParkingSpots.Core.Exceptions;

internal class ParkingSpotNotFoundException : CustomException
{
    public Guid ParkingSpotId { get; }

    public ParkingSpotNotFoundException(Guid parkingSpotId) : base($"Parking spot with ID: '{parkingSpotId}' was not found.")
    {
        ParkingSpotId = parkingSpotId;
    }
}