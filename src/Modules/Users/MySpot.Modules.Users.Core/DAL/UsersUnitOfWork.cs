using MySpot.Shared.Infrastructure.Postgres;

namespace MySpot.Modules.Users.Core.DAL;

internal class UsersUnitOfWork : PostgresUnitOfWork<UsersDbContext>
{
    public UsersUnitOfWork(UsersDbContext dbContext) : base(dbContext)
    {
    }
}