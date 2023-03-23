using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Users.Core.Exceptions;

internal class MissingPasswordException : CustomException
{
    public MissingPasswordException() : base($"Invalid password")
    {
    }
}