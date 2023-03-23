using System;
using System.Collections.Generic;
using Chronicle;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySpot.Shared.Abstractions.Modules;

namespace MySpot.Modules.Saga.Api;

internal sealed class SagaModule : IModule
{
    public string Name { get; } = "Saga";

    public IEnumerable<string> Policies { get; } = Array.Empty<string>();

    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddChronicle();
    }
        
    public void Use(IApplicationBuilder app)
    {
    }

    public void Expose(IEndpointRouteBuilder endpoints)
    {
    }
}