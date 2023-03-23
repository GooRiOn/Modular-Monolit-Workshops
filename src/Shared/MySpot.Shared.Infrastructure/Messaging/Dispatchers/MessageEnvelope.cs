using MySpot.Shared.Abstractions.Messaging;

namespace MySpot.Shared.Infrastructure.Messaging.Dispatchers;

public record MessageEnvelope(IMessage Message, IMessageContext MessageContext);