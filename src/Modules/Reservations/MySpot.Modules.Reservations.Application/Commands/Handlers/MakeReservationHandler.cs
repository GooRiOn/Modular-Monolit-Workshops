using MySpot.Modules.Reservations.Core.ValueObjects;
using MySpot.Shared.Abstractions.Commands;

namespace MySpot.Modules.Reservations.Application.Commands.Handlers;

internal sealed class MakeReservationHandler : ICommandHandler<MakeReservation>
{
    public async Task HandleAsync(MakeReservation command, CancellationToken cancellationToken = default)
    {
        var (userId, parkingSpotId, capacity, licensePlate, date, note) = command;
        _ = new LicensePlate(licensePlate);
        _ = new Capacity(capacity);
        _ = new Date(date);

        //TODO: Implement the make reservation use case
        await Task.CompletedTask;
    }
}