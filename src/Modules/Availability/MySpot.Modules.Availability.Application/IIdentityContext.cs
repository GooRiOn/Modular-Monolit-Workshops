using System;
using System.Collections.Generic;

namespace MySpot.Modules.Availability.Application;

public interface IIdentityContext
{
    Guid Id { get; }
    string Role { get; }
    bool IsAuthenticated { get; }
    bool IsAdmin { get; }
    IDictionary<string, string> Claims { get; }
}