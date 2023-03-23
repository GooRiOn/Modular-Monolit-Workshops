using System.Threading;
using System.Threading.Tasks;
using MySpot.Modules.Availability.Application.Events;
using MySpot.Modules.Availability.Application.Exceptions;
using MySpot.Modules.Availability.Core.Repositories;
using MySpot.Shared.Abstractions.Commands;
using MySpot.Shared.Abstractions.Messaging;

namespace MySpot.Modules.Availability.Application.Commands.Handlers;

internal sealed class DeleteResourceHandler : ICommandHandler<DeleteResource>
{
    private readonly IResourcesRepository _repository;
    private readonly IMessageBroker _messageBroker;

    public DeleteResourceHandler(IResourcesRepository repository, IMessageBroker messageBroker)
    {
        _repository = repository;
        _messageBroker = messageBroker;
    }
        
    public async Task HandleAsync(DeleteResource command, CancellationToken cancellationToken = default)
    {
        var resource = await _repository.GetAsync(command.ResourceId);
        if (resource is null)
        {
            throw new ResourceNotFoundException(command.ResourceId);
        }

        resource.Delete();
        await _repository.DeleteAsync(resource);
        await _messageBroker.PublishAsync(new ResourceDeleted(resource.Id), cancellationToken);
    }
}