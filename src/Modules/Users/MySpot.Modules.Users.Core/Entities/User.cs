using System;

namespace MySpot.Modules.Users.Core.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string JobTitle { get; set; }
    public Role Role { get; set; } = new();
    public string RoleId { get; set; }
    public DateTime CreatedAt { get; set; }
}