﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MySpot.Shared.Abstractions.Contexts;
using MySpot.Shared.Abstractions.Messaging;
using MySpot.Shared.Abstractions.Modules;
using MySpot.Shared.Infrastructure.Messaging.Contexts;
using MySpot.Shared.Infrastructure.Messaging.Dispatchers;
using MySpot.Shared.Infrastructure.Messaging.Outbox;

namespace MySpot.Shared.Infrastructure.Messaging.Brokers;

public sealed class InMemoryMessageBroker : IMessageBroker
{
    private readonly IModuleClient _moduleClient;
    private readonly IAsyncMessageDispatcher _asyncMessageDispatcher;
    private readonly IContext _context;
    private readonly IOutboxBroker _outboxBroker;
    private readonly IMessageContextRegistry _messageContextRegistry;
    private readonly ILogger<InMemoryMessageBroker> _logger;
    private readonly bool _useAsyncDispatcher;

    public InMemoryMessageBroker(IModuleClient moduleClient, IAsyncMessageDispatcher asyncMessageDispatcher,
        IContext context, IOutboxBroker outboxBroker, IMessageContextRegistry messageContextRegistry,
        IOptions<MessagingOptions> messagingOptions,ILogger<InMemoryMessageBroker> logger)
    {
        _moduleClient = moduleClient;
        _asyncMessageDispatcher = asyncMessageDispatcher;
        _context = context;
        _outboxBroker = outboxBroker;
        _messageContextRegistry = messageContextRegistry;
        _useAsyncDispatcher = messagingOptions.Value.UseAsyncDispatcher;
        _logger = logger;
    }

    public Task PublishAsync(IMessage message, CancellationToken cancellationToken = default)
        => PublishAsync(cancellationToken, message);

    public Task PublishAsync(IMessage[] messages, CancellationToken cancellationToken = default)
        => PublishAsync(cancellationToken, messages);
        
    private async Task PublishAsync(CancellationToken cancellationToken, params IMessage[] messages)
    {
        if (messages is null)
        {
            return;
        }

        messages = messages.Where(x => x is not null).ToArray();

        if (!messages.Any())
        {
            return;
        }

        foreach (var message in messages)
        {
            var messageContext = new MessageContext(Guid.NewGuid(), _context);
            _messageContextRegistry.Set(message, messageContext);
                
            var module = message.GetModuleName();
            var name = message.GetType().Name.Underscore();
            var requestId = _context.RequestId;
            var traceId = _context.TraceId;
            var userId = _context.Identity?.Id;
            var messageId = messageContext.MessageId;
            var correlationId = messageContext.Context.CorrelationId;
                
            _logger.LogInformation("Publishing a message: {Name} ({Module}) [Request ID: {RequestId}, Message ID: {MessageId}, Correlation ID: {CorrelationId}, Trace ID: '{TraceId}', User ID: '{UserId}]...",
                name, module, requestId, messageId, correlationId, traceId, userId);
        }

        if (_outboxBroker.Enabled)
        {
            await _outboxBroker.SendAsync(messages);
            return;
        }

        var tasks = _useAsyncDispatcher
            ? messages.Select(message => _asyncMessageDispatcher.PublishAsync(message, cancellationToken))
            : messages.Select(message => _moduleClient.PublishAsync(message, cancellationToken));

        await Task.WhenAll(tasks);
    }
}