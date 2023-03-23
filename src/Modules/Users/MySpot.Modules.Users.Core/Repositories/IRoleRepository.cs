using System.Collections.Generic;
using System.Threading.Tasks;
using MySpot.Modules.Users.Core.Entities;

namespace MySpot.Modules.Users.Core.Repositories;

internal interface IRoleRepository
{
    Task<Role> GetAsync(string name);
    Task<IReadOnlyList<Role>> GetAllAsync();
    Task AddAsync(Role role);
}