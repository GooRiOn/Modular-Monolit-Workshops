using System;
using MySpot.Modules.Users.Core.DTO;
using MySpot.Shared.Abstractions.Queries;

namespace MySpot.Modules.Users.Core.Queries;

internal class GetUser : IQuery<UserDetailsDto>
{
    public Guid UserId { get; set; }
}