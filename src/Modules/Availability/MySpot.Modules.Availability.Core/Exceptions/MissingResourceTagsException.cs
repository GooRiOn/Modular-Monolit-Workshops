using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Availability.Core.Exceptions;

public class MissingResourceTagsException : CustomException
{
    public MissingResourceTagsException() : base("Resource tags are missing.")
    {
    }
}