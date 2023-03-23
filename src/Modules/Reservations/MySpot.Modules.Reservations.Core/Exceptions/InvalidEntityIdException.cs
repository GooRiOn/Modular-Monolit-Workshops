using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Reservations.Core.Exceptions;

public sealed class InvalidEntityIdException : CustomException
{
    public object Id { get; }

    public InvalidEntityIdException(object id) : base($"Cannot set: {id}  as entity identifier.")
        => Id = id;
}