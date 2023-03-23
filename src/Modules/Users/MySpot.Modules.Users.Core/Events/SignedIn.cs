using System;
using MySpot.Shared.Abstractions.Events;

namespace MySpot.Modules.Users.Core.Events;

internal record SignedIn(Guid UserId) : IEvent;