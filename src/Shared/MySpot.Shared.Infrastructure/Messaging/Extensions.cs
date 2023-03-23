using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySpot.Shared.Abstractions.Messaging;
using MySpot.Shared.Infrastructure.Messaging.Brokers;
using MySpot.Shared.Infrastructure.Messaging.Contexts;
using MySpot.Shared.Infrastructure.Messaging.Dispatchers;

namespace MySpot.Shared.Infrastructure.Messaging;

public static class Extensions
{
    private const string SectionName = "messaging";

    public static IServiceCollection AddMessaging(this IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetSection(SectionName);
        services.Configure<MessagingOptions>(section);
        var messagingOptions = section.BindOptions<MessagingOptions>();

        services.AddTransient<IMessageBroker, InMemoryMessageBroker>();
        services.AddTransient<IAsyncMessageDispatcher, AsyncMessageDispatcher>();
        services.AddSingleton<IMessageChannel, MessageChannel>();
        services.AddSingleton<IMessageContextProvider, MessageContextProvider>();
        services.AddSingleton<IMessageContextRegistry, MessageContextRegistry>();

        if (messagingOptions.UseAsyncDispatcher)
        {
            services.AddHostedService<AsyncDispatcherJob>();
        }

        return services;
    }
}