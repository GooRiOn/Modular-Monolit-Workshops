using System;
using MySpot.Shared.Abstractions.Time;

namespace MySpot.Shared.Infrastructure.Time;

public class UtcClock : IClock
{
    public DateTime CurrentDate() => DateTime.UtcNow;
}