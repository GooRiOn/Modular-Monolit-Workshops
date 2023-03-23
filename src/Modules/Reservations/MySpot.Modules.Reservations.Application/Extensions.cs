using Microsoft.Extensions.DependencyInjection;
using MySpot.Modules.Reservations.Core.DomainServices;
using MySpot.Modules.Reservations.Core.Policies;

namespace MySpot.Modules.Reservations.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assemblies = typeof(IReservationPolicy).Assembly;
        services.AddSingleton<IWeeklyReservationsService, WeeklyReservationsService>();

        services.Scan(s => s.FromAssemblies(assemblies)
            .AddClasses(c => c.AssignableTo<IReservationPolicy>())
            .AsImplementedInterfaces()
            .WithSingletonLifetime());
        
        return services;
    }
}