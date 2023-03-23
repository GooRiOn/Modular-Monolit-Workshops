using MySpot.Modules.Reservations.Core.Entities;
using MySpot.Modules.Reservations.Core.Types;
using MySpot.Modules.Reservations.Core.ValueObjects;

namespace MySpot.Modules.Reservations.Core.Factories;

public interface IWeeklyReservationsFactory
{
    Task<WeeklyReservations> CreateAsync(UserId userId, Week week, CancellationToken cancellationToken = default);
}