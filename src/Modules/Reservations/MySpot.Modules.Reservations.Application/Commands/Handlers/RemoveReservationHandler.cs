using MySpot.Modules.Reservations.Application.Exceptions;
using MySpot.Modules.Reservations.Core.Repositories;
using MySpot.Shared.Abstractions.Commands;

namespace MySpot.Modules.Reservations.Application.Commands.Handlers;

internal sealed class RemoveReservationHandler : ICommandHandler<RemoveReservation>
{
    private readonly IWeeklyReservationsRepository _repository;

    public RemoveReservationHandler(IWeeklyReservationsRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(RemoveReservation command, CancellationToken cancellationToken = default)
    {
        var (userId, reservationId) = command;

        var weeklyReservations = await _repository.GetForCurrentWeekAsync(userId, cancellationToken);

        if (weeklyReservations is null)
        {
            throw new WeeklyReservationsForCurrentWeekNotFound();
        }
        
        weeklyReservations.RemoveReservation(reservationId);
        await _repository.UpdateAsync(weeklyReservations, cancellationToken);
    }
}