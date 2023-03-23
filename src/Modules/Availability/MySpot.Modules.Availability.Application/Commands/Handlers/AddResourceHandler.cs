using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MySpot.Modules.Availability.Application.Events;
using MySpot.Modules.Availability.Application.Exceptions;
using MySpot.Modules.Availability.Core.Entities;
using MySpot.Modules.Availability.Core.Repositories;
using MySpot.Modules.Availability.Core.ValueObjects;
using MySpot.Shared.Abstractions.Commands;
using MySpot.Shared.Abstractions.Messaging;

namespace MySpot.Modules.Availability.Application.Commands.Handlers;

internal sealed class AddResourceHandler : ICommandHandler<AddResource>
{
    private readonly IResourcesRepository _repository;
    private readonly IMessageBroker _messageBroker;

    public AddResourceHandler(IResourcesRepository repository, IMessageBroker messageBroker)
    {
        _repository = repository;
        _messageBroker = messageBroker;
    }
        
    public async Task HandleAsync(AddResource command, CancellationToken cancellationToken = default)
    {
        var (resourceId, capacity, tags) = command;
        if (await _repository.ExistsAsync(resourceId))
        {
            throw new ResourceAlreadyExistsException(command.ResourceId);
        }
            
        var resource = Resource.Create(resourceId, capacity, tags.Select(t => new Tag(t)));
        await _repository.AddAsync(resource);
        await _messageBroker.PublishAsync(new ResourceAdded(resourceId), cancellationToken);
    }
}