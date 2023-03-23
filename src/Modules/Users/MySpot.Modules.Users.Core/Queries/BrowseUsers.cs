using MySpot.Modules.Users.Core.DTO;
using MySpot.Shared.Abstractions.Queries;

namespace MySpot.Modules.Users.Core.Queries;

internal class BrowseUsers : PagedQuery<UserDto>
{
    public string Email { get; set; }
    public string Role { get; set; }
    public string State { get; set; }
}