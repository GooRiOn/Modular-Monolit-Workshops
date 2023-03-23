using System;
using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Users.Core.Exceptions;

internal class UserStateCannotBeChangedException : CustomException
{
    public string State { get; }
    public Guid UserId { get; }

    public UserStateCannotBeChangedException(string state, Guid userId)
        : base($"User state cannot be changed to: '{state}' for user with ID: '{userId}'.")
    {
        State = state;
        UserId = userId;
    }
}