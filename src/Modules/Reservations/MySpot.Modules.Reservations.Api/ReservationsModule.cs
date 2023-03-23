using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySpot.Modules.Reservations.Application;
using MySpot.Modules.Reservations.Application.Commands;
using MySpot.Modules.Reservations.Core;
using MySpot.Modules.Reservations.Infrastructure;
using MySpot.Shared.Abstractions.Dispatchers;
using MySpot.Shared.Abstractions.Modules;

namespace MySpot.Modules.Reservations.Api;

internal sealed class ReservationsModule : IModule
{
    public string Name { get; } = "Reservations";
        
    public IEnumerable<string> Policies { get; } = new[]
    {
        "reservations"
    };

    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddCore()
            .AddApplication()
            .AddInfrastructure(configuration);
    }
        
    public void Use(IApplicationBuilder app)
    {
    }

    public void Expose(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/reservations", async (MakeReservation command, IDispatcher dispatcher, HttpContext context) =>
        {
            await dispatcher.SendAsync(command with {UserId = UserId(context)});
            return Results.Accepted();
        }).RequireAuthorization().WithTags("Reservations").WithName("Make reservation");

        endpoints.MapDelete("/reservations/{id:guid}", async (Guid id, IDispatcher dispatcher, HttpContext context) =>
        {
            await dispatcher.SendAsync(new RemoveReservation(id, UserId(context)));
            return Results.NoContent();
        }).RequireAuthorization().WithTags("Reservations").WithName("Remove reservation");
        
        static Guid UserId(HttpContext context)
            => string.IsNullOrWhiteSpace(context.User.Identity?.Name) ? Guid.Empty : Guid.Parse(context.User.Identity.Name);
    }
}