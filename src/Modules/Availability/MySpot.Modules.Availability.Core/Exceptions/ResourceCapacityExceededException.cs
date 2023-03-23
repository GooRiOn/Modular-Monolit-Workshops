using System;
using MySpot.Modules.Availability.Core.ValueObjects;
using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Availability.Core.Exceptions;

public class ResourceCapacityExceededException : CustomException
{
    private readonly Capacity _capacity;
    public Guid ResourceId { get; }

    public ResourceCapacityExceededException(Guid resourceId, Capacity capacity) 
        : base($"Resource with ID: {resourceId} exceeded capacity of {capacity}")
    {
        _capacity = capacity;
        ResourceId = resourceId;
    }
}