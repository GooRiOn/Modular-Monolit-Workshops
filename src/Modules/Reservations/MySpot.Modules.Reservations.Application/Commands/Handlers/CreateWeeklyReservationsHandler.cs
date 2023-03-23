using MySpot.Modules.Reservations.Core.Factories;
using MySpot.Modules.Reservations.Core.Repositories;
using MySpot.Modules.Reservations.Core.Types;
using MySpot.Modules.Reservations.Core.ValueObjects;
using MySpot.Shared.Abstractions.Commands;
using MySpot.Shared.Abstractions.Time;

namespace MySpot.Modules.Reservations.Application.Commands.Handlers;

internal sealed class CreateWeeklyReservationsHandler : ICommandHandler<CreateWeeklyReservations>
{
    private readonly IWeeklyReservationsFactory _weeklyReservationsFactory;
    private readonly IWeeklyReservationsRepository _weeklyReservationsRepository;
    private readonly IClock _clock;

    public CreateWeeklyReservationsHandler(IWeeklyReservationsFactory weeklyReservationsFactory,
        IWeeklyReservationsRepository weeklyReservationsRepository, IClock clock)
    {
        _weeklyReservationsFactory = weeklyReservationsFactory;
        _weeklyReservationsRepository = weeklyReservationsRepository;
        _clock = clock;
    }

    public async Task HandleAsync(CreateWeeklyReservations command, CancellationToken cancellationToken = default)
    {
        var userId = new UserId(command.UserId);
        var week = new Week(_clock.CurrentDate());
        var weeklyReservations = await _weeklyReservationsRepository.GetForCurrentWeekAsync(userId, cancellationToken);
        if (weeklyReservations is not null)
        {
            return;
        }

        weeklyReservations = await _weeklyReservationsFactory.CreateAsync(userId, week, cancellationToken);
        await _weeklyReservationsRepository.AddAsync(weeklyReservations, cancellationToken);
    }
}