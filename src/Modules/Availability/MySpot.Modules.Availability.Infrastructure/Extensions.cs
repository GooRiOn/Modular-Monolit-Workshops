using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySpot.Modules.Availability.Core.Repositories;
using MySpot.Modules.Availability.Infrastructure.DAL;
using MySpot.Modules.Availability.Infrastructure.DAL.Repositories;
using MySpot.Shared.Infrastructure.Postgres;

namespace MySpot.Modules.Availability.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddTransient<IResourcesRepository, ResourcesRepository>()
            .AddPostgres<AvailabilityDbContext>(configuration)
            .AddUnitOfWork<AvailabilityUnitOfWork>();
}