using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Reservations.Core.Exceptions;

public sealed class NoReservationPolicyFoundException : CustomException
{
    public string Participant { get; }

    public NoReservationPolicyFoundException(string participant) 
        : base($"No reservation policy found for participant: {participant}")
    {
        Participant = participant;
    }
}