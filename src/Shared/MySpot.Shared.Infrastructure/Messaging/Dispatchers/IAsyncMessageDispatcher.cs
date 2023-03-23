using System.Threading;
using System.Threading.Tasks;
using MySpot.Shared.Abstractions.Messaging;

namespace MySpot.Shared.Infrastructure.Messaging.Dispatchers;

public interface IAsyncMessageDispatcher
{
    Task PublishAsync<TMessage>(TMessage message, CancellationToken cancellationToken = default)
        where TMessage : class, IMessage;
}