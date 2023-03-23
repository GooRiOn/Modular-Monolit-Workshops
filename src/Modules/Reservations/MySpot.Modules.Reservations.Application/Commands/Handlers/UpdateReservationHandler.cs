using MySpot.Modules.Reservations.Core.Entities;
using MySpot.Modules.Reservations.Core.Repositories;
using MySpot.Shared.Abstractions.Commands;
using MySpot.Shared.Abstractions.Contexts;
using MySpot.Shared.Abstractions.Domain;

namespace MySpot.Modules.Reservations.Application.Commands.Handlers;

internal sealed class UpdateReservationHandler : 
    ICommandHandler<ChangeReservationNote>,
    ICommandHandler<ChangeReservationLicencePlate>,
    ICommandHandler<MakeReservationIncorrect>,
    ICommandHandler<VerifyReservation>
{
    private readonly IWeeklyReservationsRepository _repository;
    private readonly IContext _context;

    public UpdateReservationHandler(IWeeklyReservationsRepository repository, IContext context)
    {
        _repository = repository;
        _context = context;
    }

    public async Task HandleAsync(ChangeReservationNote command, CancellationToken cancellationToken = default)
    {
        var (weeklyReservationsId, reservationId, note) = command;
        await UpdateReservationsAsync(weeklyReservationsId, 
            x => x.ChangeReservationsNote(reservationId, note), cancellationToken);
    }

    public async Task HandleAsync(ChangeReservationLicencePlate command, CancellationToken cancellationToken = default)
    {
        var (weeklyReservationsId, reservationId, licencePlate) = command;
        await UpdateReservationsAsync(weeklyReservationsId, 
            x => x.ChangeLicensePlate(reservationId, licencePlate), cancellationToken);
    }

    public async Task HandleAsync(MakeReservationIncorrect command, CancellationToken cancellationToken = default)
    {
        var (weeklyReservationsId, reservationId) = command;
        await UpdateReservationsAsync(weeklyReservationsId, 
            x => x.MarkReservationAsIncorrect(reservationId), cancellationToken);
    }

    public async Task HandleAsync(VerifyReservation command, CancellationToken cancellationToken = default)
    {
        var (weeklyReservationsId, reservationId) = command;
        await UpdateReservationsAsync(weeklyReservationsId, 
            x => x.MarkReservationAsVerified(reservationId), cancellationToken);
    }

    private async Task UpdateReservationsAsync(AggregateId weeklyReservationsId,
        Action<WeeklyReservations> update,
        CancellationToken cancellationToken = default)
    {
        var userId = _context.Identity.Id;
        var weeklyReservations = await _repository.GetForCurrentWeekAsync(userId, cancellationToken);
        update(weeklyReservations);
        await _repository.UpdateAsync(weeklyReservations, cancellationToken);
    }
}