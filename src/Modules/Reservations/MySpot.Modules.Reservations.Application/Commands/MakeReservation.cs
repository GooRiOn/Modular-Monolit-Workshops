using MySpot.Shared.Abstractions.Commands;

namespace MySpot.Modules.Reservations.Application.Commands;

public record MakeReservation(Guid UserId, Guid ParkingSpotId, int Capacity, string LicensePlate, DateTimeOffset Date,
    string Note = null) : ICommand;