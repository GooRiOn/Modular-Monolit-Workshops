using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Users.Core.Exceptions;

internal class InvalidEmailException : CustomException
{
    public string Email { get; }

    public InvalidEmailException(string email) : base($"State is invalid: '{email}'.")
    {
        Email = email;
    }
}