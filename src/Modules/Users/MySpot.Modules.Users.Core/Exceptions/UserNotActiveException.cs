using System;
using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Users.Core.Exceptions;

internal class UserNotActiveException : CustomException
{
    public Guid UserId { get; }

    public UserNotActiveException(Guid userId) : base($"User with ID: '{userId}' is not active.")
    {
        UserId = userId;
    }
}