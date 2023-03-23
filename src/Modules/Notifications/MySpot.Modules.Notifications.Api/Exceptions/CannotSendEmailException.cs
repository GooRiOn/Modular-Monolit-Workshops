using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Notifications.Api.Exceptions;

internal sealed class CannotSendEmailException : CustomException
{
    public string Receiver { get; }

    public CannotSendEmailException(string receiver) : base($"Cannot send an email to: '{receiver}'.")
    {
        Receiver = receiver;
    }
}