using Microsoft.EntityFrameworkCore;
using MySpot.Modules.Reservations.Application.DTO;
using MySpot.Modules.Reservations.Application.Queries;
using MySpot.Modules.Reservations.Core.Entities;
using MySpot.Modules.Reservations.Core.ValueObjects;
using MySpot.Shared.Abstractions.Queries;
using MySpot.Shared.Abstractions.Time;

namespace MySpot.Modules.Reservations.Infrastructure.DAL.Handlers;

internal sealed class GetWeeklyReservationsHandler : IQueryHandler<GetWeeklyReservations, WeeklyReservationsDto>
{
    private readonly DbSet<WeeklyReservations> _weeklyReservations;
    private readonly IClock _clock;

    public GetWeeklyReservationsHandler(ReservationsDbContext context, IClock clock)
    {
        _weeklyReservations = context.WeeklyReservations;
        _clock = clock;
    }

    public Task<WeeklyReservationsDto> HandleAsync(GetWeeklyReservations query,
        CancellationToken cancellationToken = default)
    {
        var week = new Week(query.Date ?? _clock.CurrentDate());

        return _weeklyReservations
            .AsNoTracking()
            .Where(x => x.UserId == query.UserId && x.Week == week)
            .Select(x => x.AsDto())
            .SingleOrDefaultAsync(cancellationToken);
    }
}