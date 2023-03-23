using System.Threading.Tasks;
using MySpot.Modules.Availability.Core.Entities;
using MySpot.Shared.Abstractions.Domain;

namespace MySpot.Modules.Availability.Core.Repositories;

public interface IResourcesRepository
{
    Task<Resource> GetAsync(AggregateId id);
    Task<bool> ExistsAsync(AggregateId id);
    Task AddAsync(Resource resource);
    Task UpdateAsync(Resource resource);
    Task DeleteAsync(Resource resource);
}