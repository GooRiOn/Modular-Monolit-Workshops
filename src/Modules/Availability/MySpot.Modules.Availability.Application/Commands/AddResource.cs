using System;
using System.Collections.Generic;
using MySpot.Shared.Abstractions.Commands;

namespace MySpot.Modules.Availability.Application.Commands;

public record AddResource(Guid ResourceId, int Capacity, IEnumerable<string> Tags) : ICommand;