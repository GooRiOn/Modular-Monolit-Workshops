using System.Collections.Generic;

namespace MySpot.Shared.Infrastructure.Modules;

public record ModuleInfo(string Name, IEnumerable<string> Policies);