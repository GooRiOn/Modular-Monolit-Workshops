using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySpot.Modules.Cleaning.Core;
using MySpot.Shared.Abstractions.Modules;

namespace MySpot.Modules.Cleaning.Api;

public class CleaningModule : IModule
{
    public string Name { get; } = "Cleaning";
    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddCore();
    }

    public void Use(IApplicationBuilder app)
    {
    }

    public void Expose(IEndpointRouteBuilder endpoints)
    {
    }
}