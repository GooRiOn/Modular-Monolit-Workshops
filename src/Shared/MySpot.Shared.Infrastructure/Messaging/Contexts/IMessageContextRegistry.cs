using MySpot.Shared.Abstractions.Messaging;

namespace MySpot.Shared.Infrastructure.Messaging.Contexts;

public interface IMessageContextRegistry
{
    void Set(IMessage message, IMessageContext context);
}