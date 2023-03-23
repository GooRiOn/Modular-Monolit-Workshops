using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Users.Core.Exceptions;

internal class RoleNotFoundException : CustomException
{
    public RoleNotFoundException(string role) : base($"Role: '{role}' was not found.")
    {
    }
}