using System;
using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Availability.Application.Exceptions;

public class ResourceNotFoundException : CustomException
{
    public Guid Id { get; }

    public ResourceNotFoundException(Guid id) : base($"Resource with id: {id} was not found.")
        => Id = id;
}