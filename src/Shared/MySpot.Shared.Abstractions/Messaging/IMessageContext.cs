using System;
using MySpot.Shared.Abstractions.Contexts;

namespace MySpot.Shared.Abstractions.Messaging;

public interface IMessageContext
{
    public Guid MessageId { get; }
    public IContext Context { get; }
}