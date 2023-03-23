using MySpot.Modules.Availability.Core.Entities;
using MySpot.Shared.Abstractions.Domain;

namespace MySpot.Modules.Availability.Core.Events;

public class ResourceDeleted : IDomainEvent
{
    public Resource Resource { get; }

    public ResourceDeleted(Resource resource)
        => Resource = resource;
}