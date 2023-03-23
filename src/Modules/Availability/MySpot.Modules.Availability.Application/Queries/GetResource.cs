using System;
using MySpot.Modules.Availability.Application.DTO;
using MySpot.Shared.Abstractions.Queries;

namespace MySpot.Modules.Availability.Application.Queries;

public class GetResource : IQuery<ResourceDto>
{
    public Guid ResourceId { get; set; }
}