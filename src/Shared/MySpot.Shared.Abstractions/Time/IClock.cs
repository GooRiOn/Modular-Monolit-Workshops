using System;

namespace MySpot.Shared.Abstractions.Time;

public interface IClock
{
    DateTime CurrentDate();
}