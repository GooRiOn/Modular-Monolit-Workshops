using System;
using System.ComponentModel.DataAnnotations;
using MySpot.Shared.Abstractions.Commands;

namespace MySpot.Modules.Users.Core.Commands;

internal record SignIn([Required] [EmailAddress] string Email, [Required] string Password) : ICommand
{
    public Guid Id { get; init; } = Guid.NewGuid();
}