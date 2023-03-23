using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySpot.Modules.Users.Core.DAL;
using MySpot.Modules.Users.Core.DAL.Repositories;
using MySpot.Modules.Users.Core.Repositories;
using MySpot.Modules.Users.Core.Services;
using MySpot.Shared.Infrastructure;
using MySpot.Shared.Infrastructure.Postgres;

[assembly: InternalsVisibleTo("MySpot.Modules.Users.Api")]
[assembly: InternalsVisibleTo("MySpot.Modules.Users.Tests.Integration")]
[assembly: InternalsVisibleTo("MySpot.Modules.Users.Tests.Unit")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace MySpot.Modules.Users.Core;

internal static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        var registrationSection = configuration.GetSection("users:registration");
        var registrationOptions = registrationSection.BindOptions<RegistrationOptions>();
        services.Configure<RegistrationOptions>(registrationSection);

        return services
            .AddSingleton<ITokenStorage, HttpContextTokenStorage>()
            .AddScoped<IRoleRepository, RoleRepository>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddPostgres<UsersDbContext>(configuration)
            .AddUnitOfWork<UsersUnitOfWork>()
            .AddInitializer<UsersInitializer>();
    }
}