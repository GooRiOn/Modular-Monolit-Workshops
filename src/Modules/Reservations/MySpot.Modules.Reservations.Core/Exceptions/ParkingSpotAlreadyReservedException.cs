using MySpot.Modules.Reservations.Core.ValueObjects;
using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Reservations.Core.Exceptions;

internal sealed class ParkingSpotAlreadyReservedException : CustomException
{
    public Guid ParkingSpotId { get; }
    public DateTimeOffset Date { get; }

    public ParkingSpotAlreadyReservedException(Guid parkingSpotId, Date date)
        : base($"Parking spot with ID: {parkingSpotId} is already reserved for date: {date}.")
    {
        ParkingSpotId = parkingSpotId;
        Date = date;
    }
}