using MySpot.Modules.Availability.Core.Entities;
using MySpot.Shared.Abstractions.Domain;

namespace MySpot.Modules.Availability.Core.Events;

public class ResourceCreated : IDomainEvent
{
    public Resource Resource { get; }

    public ResourceCreated(Resource resource)
        => Resource = resource;
}