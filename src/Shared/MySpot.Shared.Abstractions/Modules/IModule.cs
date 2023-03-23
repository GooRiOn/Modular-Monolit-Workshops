using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MySpot.Shared.Abstractions.Modules;

public interface IModule
{
    string Name { get; }
    IEnumerable<string> Policies => null;
    void Register(IServiceCollection services, IConfiguration configuration);
    void Use(IApplicationBuilder app);
    void Expose(IEndpointRouteBuilder endpoints);
}