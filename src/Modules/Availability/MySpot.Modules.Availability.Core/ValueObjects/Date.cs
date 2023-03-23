using System;
using MySpot.Modules.Availability.Core.Exceptions;

namespace MySpot.Modules.Availability.Core.ValueObjects;

public sealed record Date
{
    public DateTimeOffset Value { get; }

    public Date(DateTimeOffset value)
    {
        if (value.Date < DateTime.Now.Date)
        {
            throw new PastDateException(value);
        }

        Value = value.Date;
    }
    
    public Date AddDays(int days) => new(Value.AddDays(days));
    
    public static implicit operator DateTimeOffset(Date date)
        => date.Value;
    
    public static implicit operator Date(DateTimeOffset value)
        => new(value);

    public static bool operator <(Date date1, Date date2)
        => date1.Value < date2.Value;

    public static bool operator >(Date date1, Date date2)
        => date1.Value > date2.Value;

    public static bool operator <=(Date date1, Date date2)
        => date1.Value <= date2.Value;
    
    public static bool operator >=(Date date1, Date date2)
        => date1.Value >= date2.Value;

    public static Date Now => new(DateTimeOffset.Now);

    public override string ToString() => Value.ToString("d");
}
