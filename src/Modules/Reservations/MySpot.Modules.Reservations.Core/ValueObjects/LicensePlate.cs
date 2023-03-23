using MySpot.Modules.Reservations.Core.Exceptions;

namespace MySpot.Modules.Reservations.Core.ValueObjects;

public sealed record LicensePlate
{
    public string Value { get; }

    public LicensePlate(string value)
    {
        if (value is null || value.Length is < 5 or > 8)
        {
            throw new InvalidLicensePlateException(value);
        }

        Value = value;
    }
    
    public static implicit operator string(LicensePlate licensePlate)
        => licensePlate.Value;
    
    public static implicit operator LicensePlate(string value)
        => new(value);
}
