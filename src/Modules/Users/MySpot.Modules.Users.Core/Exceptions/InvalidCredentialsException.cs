using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Users.Core.Exceptions;

internal class InvalidCredentialsException : CustomException
{
    public InvalidCredentialsException() : base("Invalid credentials.")
    {
    }
}