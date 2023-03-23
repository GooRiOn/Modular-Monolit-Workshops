using Microsoft.Extensions.DependencyInjection;
using MySpot.Modules.Reservations.Core.Factories;

namespace MySpot.Modules.Reservations.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
        => services.AddTransient<IWeeklyReservationsFactory, WeeklyReservationsFactory>();
}