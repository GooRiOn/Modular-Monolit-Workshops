using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Availability.Core.Exceptions;

public class InvalidCapacityException : CustomException
{
    public int Capacity { get; }

    public InvalidCapacityException(int capacity) : base($"Reservation capacity: {capacity} is invalid")
        => Capacity = capacity;
}