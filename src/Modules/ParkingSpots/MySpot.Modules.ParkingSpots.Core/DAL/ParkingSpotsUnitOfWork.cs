using MySpot.Shared.Infrastructure.Postgres;

namespace MySpot.Modules.ParkingSpots.Core.DAL;

internal class ParkingSpotsUnitOfWork : PostgresUnitOfWork<ParkingSpotsDbContext>
{
    public ParkingSpotsUnitOfWork(ParkingSpotsDbContext dbContext) : base(dbContext)
    {
    }
}