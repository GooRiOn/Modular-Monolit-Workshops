using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySpot.Shared.Abstractions.Modules;

namespace MySpot.Modules.Mapping.Api;

internal sealed class MappingModule : IModule
{
    public string Name { get; } = "Mapping";
        
    public IEnumerable<string> Policies { get; } = new[]
    {
        "mapping"
    };

    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        
    }
        
    public void Use(IApplicationBuilder app)
    {
    }

    public void Expose(IEndpointRouteBuilder endpoints)
    {
    }
}