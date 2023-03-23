using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Users.Core.Exceptions;

internal class InvalidPasswordException : CustomException
{
    public string Reason { get; }

    public InvalidPasswordException(string reason) : base($"Invalid password: {reason}.")
    {
        Reason = reason;
    }
}