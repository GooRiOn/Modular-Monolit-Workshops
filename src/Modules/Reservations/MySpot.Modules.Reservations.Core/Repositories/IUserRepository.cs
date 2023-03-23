using MySpot.Modules.Reservations.Core.Entities;
using MySpot.Modules.Reservations.Core.Types;

namespace MySpot.Modules.Reservations.Core.Repositories;

public interface IUserRepository
{
    Task<User> GetAsync(UserId userId, CancellationToken cancellationToken = default);
    Task AddAsync(User user, CancellationToken cancellationToken = default);
}