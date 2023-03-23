using MySpot.Shared.Infrastructure.Postgres;

namespace MySpot.Modules.Reservations.Infrastructure.DAL;

internal class ReservationsUnitOfWork : PostgresUnitOfWork<ReservationsDbContext>
{
    public ReservationsUnitOfWork(ReservationsDbContext dbContext) : base(dbContext)
    {
    }
}