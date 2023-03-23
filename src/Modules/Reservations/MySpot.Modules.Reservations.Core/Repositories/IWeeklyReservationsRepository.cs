using MySpot.Modules.Reservations.Core.Entities;
using MySpot.Modules.Reservations.Core.Types;

namespace MySpot.Modules.Reservations.Core.Repositories;

public interface IWeeklyReservationsRepository
{
    Task<WeeklyReservations> GetForLastWeekAsync(UserId userId, CancellationToken cancellationToken = default);
    Task<WeeklyReservations> GetForCurrentWeekAsync(UserId userId, CancellationToken cancellationToken = default);
    Task AddAsync(WeeklyReservations weeklyReservations, CancellationToken cancellationToken = default);
    Task UpdateAsync(WeeklyReservations weeklyReservations, CancellationToken cancellationToken = default);
}