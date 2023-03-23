using System.Collections.Generic;
using MySpot.Modules.Availability.Application.DTO;
using MySpot.Shared.Abstractions.Queries;

namespace MySpot.Modules.Availability.Application.Queries;

public class GetResources : IQuery<IEnumerable<ResourceDto>>
{
    public IEnumerable<string> Tags { get; set; }
    public bool MatchAllTags { get; set; }
}