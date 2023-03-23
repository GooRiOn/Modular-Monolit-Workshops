using System;
using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Availability.Application.Exceptions;

public class CustomerNotFoundException : CustomException 
{
    public Guid Id { get; }

    public CustomerNotFoundException(Guid id) : base($"Customer with id: {id} was not found.")
        => Id = id;
}