using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Reservations.Core.Exceptions;

public sealed class InvalidLicensePlateException : CustomException
{
    public string LicensePlate { get; }

    public InvalidLicensePlateException(string licensePlate) : base($"License plate: {licensePlate} is invalid.")
        => LicensePlate = licensePlate;
}