using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Notifications.Api.Exceptions;

internal sealed class UserNotFoundException : CustomException
{
    public Guid UserId { get; }

    public UserNotFoundException(Guid userId) : base($"User with ID: '{userId}' was not found.")
    {
        UserId = userId;
    }
}