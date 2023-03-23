using System;

namespace MySpot.Modules.Users.Core.DTO;

public class UserDto
{
    public Guid UserId { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string JobTitle { get; set; }
    public DateTime CreatedAt { get; set; }
}