using System;
using MySpot.Shared.Abstractions.Commands;

namespace MySpot.Modules.Users.Core.Commands;

public record SignUp(Guid UserId, string Email, string Password, string JobTitle = null, string Role = null) : ICommand;