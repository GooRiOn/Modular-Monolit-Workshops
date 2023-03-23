using MySpot.Shared.Infrastructure.Postgres;

namespace MySpot.Modules.Availability.Infrastructure.DAL;

internal class AvailabilityUnitOfWork : PostgresUnitOfWork<AvailabilityDbContext>
{
    public AvailabilityUnitOfWork(AvailabilityDbContext dbContext) : base(dbContext)
    {
    }
}