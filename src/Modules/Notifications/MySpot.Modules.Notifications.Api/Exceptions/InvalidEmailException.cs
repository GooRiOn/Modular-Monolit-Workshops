using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Notifications.Api.Exceptions;

internal sealed class InvalidEmailException : CustomException
{
    public string Email { get; }

    public InvalidEmailException(string email) : base($"Email is invalid: '{email}'.")
    {
        Email = email;
    }
}