using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySpot.Modules.ParkingSpots.Core;
using MySpot.Modules.ParkingSpots.Core.Entities;
using MySpot.Modules.ParkingSpots.Core.Services;
using MySpot.Shared.Abstractions.Modules;

namespace MySpot.Modules.ParkingSpots.Api;

internal sealed class ParkingSpotsModule : IModule
{
    public string Name { get; } = "Parking Spots";
        
    public IEnumerable<string> Policies { get; } = new[]
    {
        "parking_spots"
    };

    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddCore(configuration);
    }
        
    public void Use(IApplicationBuilder app)
    {
    }

    public void Expose(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/parking-spots", (IParkingSpotsService service) => service.GetAllAsync())
            .WithTags("Parking spots").WithName("Get parking spots");

        endpoints.MapPut("/parking-spots/{id:guid}", async (Guid id, ParkingSpot parkingSpot, IParkingSpotsService service) =>
        {
            parkingSpot.Id = id;
            await service.UpdateAsync(parkingSpot);
            return Results.NoContent();
        }).WithTags("Parking spots").WithName("Update parking spot");

        endpoints.MapDelete("/parking-spots/{id:guid}", async (Guid id, IParkingSpotsService service) =>
        {
            await service.DeleteAsync(id);
            return Results.NoContent();
        }).WithTags("Parking spots").WithName("Delete parking spot");
    }
}