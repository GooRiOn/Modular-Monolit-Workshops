using System;
using MySpot.Shared.Abstractions.Events;

namespace MySpot.Modules.Users.Core.Events;

public record SignedUp(Guid UserId, string Email, string Role, string JobTitle) : IEvent;