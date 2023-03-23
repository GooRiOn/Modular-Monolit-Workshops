namespace MySpot.Modules.Reservations.Core.ValueObjects;

public record ReservationState(string Value)
{
    public const string Unverified = nameof(Unverified);
    public const string Verified = nameof(Verified);
    public const string Incorrect = nameof(Incorrect);

    public static implicit operator string(ReservationState licensePlate)
        => licensePlate.Value;
    
    public static implicit operator ReservationState(string value)
        => new(value);
}