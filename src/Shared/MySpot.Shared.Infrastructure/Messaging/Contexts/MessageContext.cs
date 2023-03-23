using System;
using MySpot.Shared.Abstractions.Contexts;
using MySpot.Shared.Abstractions.Messaging;

namespace MySpot.Shared.Infrastructure.Messaging.Contexts;

public class MessageContext : IMessageContext
{
    public Guid MessageId { get; }
    public IContext Context { get; }

    public MessageContext(Guid messageId, IContext context)
    {
        MessageId = messageId;
        Context = context;
    }
}