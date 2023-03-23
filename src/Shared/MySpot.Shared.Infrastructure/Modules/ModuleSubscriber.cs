using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MySpot.Shared.Abstractions.Modules;

namespace MySpot.Shared.Infrastructure.Modules;

public sealed class ModuleSubscriber : IModuleSubscriber
{
    private readonly IModuleRegistry _moduleRegistry;
    private readonly IServiceProvider _serviceProvider;

    public ModuleSubscriber(IModuleRegistry moduleRegistry, IServiceProvider serviceProvider)
    {
        _moduleRegistry = moduleRegistry;
        _serviceProvider = serviceProvider;
    }

    public IModuleSubscriber Subscribe<TRequest, TResponse>(string path,
        Func<TRequest, IServiceProvider, CancellationToken, Task<TResponse>> action)
        where TRequest : class where TResponse : class
    {
        _moduleRegistry.AddRequestAction(path, typeof(TRequest), typeof(TResponse),
            async (request, cancellationToken) =>
            {
                await using var scope = _serviceProvider.CreateAsyncScope();
                return await action((TRequest) request, scope.ServiceProvider, cancellationToken);
            });

        return this;
    }

    public IModuleSubscriber Subscribe<TRequest>(string path,
        Func<TRequest, IServiceProvider, CancellationToken, Task> action) where TRequest : class
    {
        _moduleRegistry.AddRequestAction(path, typeof(TRequest), typeof(object),
            async (request, cancellationToken) =>
            {
                await using var scope = _serviceProvider.CreateAsyncScope();
                await action((TRequest) request, scope.ServiceProvider, cancellationToken);
                return default;
            });

        return this;
    }
}