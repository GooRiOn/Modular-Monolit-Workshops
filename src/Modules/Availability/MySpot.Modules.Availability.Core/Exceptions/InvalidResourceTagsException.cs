using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Availability.Core.Exceptions;

public class InvalidResourceTagsException : CustomException
{
    public InvalidResourceTagsException() : base("Resource tags are invalid.")
    {
    }
}