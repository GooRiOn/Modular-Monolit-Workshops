using Microsoft.EntityFrameworkCore;
using MySpot.Modules.Reservations.Core.Entities;
using MySpot.Modules.Reservations.Core.Repositories;
using MySpot.Modules.Reservations.Core.Types;
using MySpot.Modules.Reservations.Core.ValueObjects;
using MySpot.Shared.Abstractions.Time;

namespace MySpot.Modules.Reservations.Infrastructure.DAL.Repositories;

internal sealed class WeeklyReservationsRepository : IWeeklyReservationsRepository
{
    private readonly DbSet<WeeklyReservations> _weeklyReservations;
    private readonly ReservationsDbContext _context;
    private readonly IClock _clock;

    public WeeklyReservationsRepository(ReservationsDbContext context, IClock clock)
    {
        _weeklyReservations = context.WeeklyReservations;
        _context = context;
        _clock = clock;
    }

    public Task<WeeklyReservations> GetForLastWeekAsync(UserId userId, CancellationToken cancellationToken = default)
        => GetForWeekAsync(userId, _clock.CurrentDate().AddDays(-7), cancellationToken, true);

    public Task<WeeklyReservations> GetForCurrentWeekAsync(UserId userId,
        CancellationToken cancellationToken = default)
        => GetForWeekAsync(userId, _clock.CurrentDate(), cancellationToken);

    public async Task AddAsync(WeeklyReservations weeklyReservations, CancellationToken cancellationToken = default)
    {
        await _weeklyReservations.AddAsync(weeklyReservations, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(WeeklyReservations weeklyReservations, CancellationToken cancellationToken = default)
    {
        _weeklyReservations.Update(weeklyReservations);
        await _context.SaveChangesAsync(cancellationToken);
    }

    private Task<WeeklyReservations> GetForWeekAsync(UserId userId, DateTime date, CancellationToken cancellationToken,
        bool withoutTracking = false)
    {
        var week = new Week(date);
        var query = _weeklyReservations
            .Where(x => x.UserId == userId && x.Week == week);

        if (withoutTracking)
        {
            query = query.AsNoTracking();
        }
        
        return query
            .Include(x => x.Reservations)
            .SingleOrDefaultAsync(cancellationToken);
    }
}