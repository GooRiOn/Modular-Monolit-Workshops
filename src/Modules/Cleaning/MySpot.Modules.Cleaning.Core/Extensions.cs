using Microsoft.Extensions.DependencyInjection;
using MySpot.Modules.Cleaning.Core.Services;

namespace MySpot.Modules.Cleaning.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddTransient<ICleaningService, CleaningService>();
        return services;
    }
}