using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MySpot.Modules.Users.Core.Entities;
using MySpot.Modules.Users.Core.Events;
using MySpot.Modules.Users.Core.Exceptions;
using MySpot.Modules.Users.Core.Repositories;
using MySpot.Shared.Abstractions.Commands;
using MySpot.Shared.Abstractions.Messaging;
using MySpot.Shared.Abstractions.Time;
using MySpot.Shared.Infrastructure.Security;

namespace MySpot.Modules.Users.Core.Commands.Handlers;

internal sealed class SignUpHandler : ICommandHandler<SignUp>
{
    private static readonly EmailAddressAttribute EmailAddressAttribute = new();
    private static readonly string DefaultRole = Role.Default;
    private const string DefaultJobTitle = "employee";
    
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IPasswordManager _passwordManager;
    private readonly IClock _clock;
    private readonly IMessageBroker _messageBroker;
    private readonly ILogger<SignUpHandler> _logger;

    public SignUpHandler(IUserRepository userRepository, IRoleRepository roleRepository,
        IPasswordManager passwordManager, IClock clock, IMessageBroker messageBroker,
        ILogger<SignUpHandler> logger)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _passwordManager = passwordManager;
        _clock = clock;
        _messageBroker = messageBroker;
        _logger = logger;
    }

    public async Task HandleAsync(SignUp command, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(command.Email) || !EmailAddressAttribute.IsValid(command.Email))
        {
            throw new InvalidEmailException(command.Email);
        }

        if (string.IsNullOrWhiteSpace(command.Password))
        {
            throw new MissingPasswordException();
        }

        var email = command.Email.ToLowerInvariant();
        var user = await _userRepository.GetAsync(email);
        if (user is not null)
        {
            throw new EmailInUseException();
        }

        var roleName = string.IsNullOrWhiteSpace(command.Role) ? DefaultRole : command.Role.ToLowerInvariant();
        var role = await _roleRepository.GetAsync(roleName);
        if (role is null)
        {
            throw new RoleNotFoundException(roleName);
        }

        var jobTitle = string.IsNullOrWhiteSpace(command.JobTitle)
            ? DefaultJobTitle
            : command.JobTitle.ToLowerInvariant();
        
        var now = _clock.CurrentDate();
        var password = _passwordManager.Secure(command.Password);
        user = new User
        {
            Id = command.UserId,
            Email = email,
            Password = password,
            Role = role,
            JobTitle = jobTitle,
            CreatedAt = now
        };
        await _userRepository.AddAsync(user);
        await _messageBroker.PublishAsync(new SignedUp(user.Id, email, role.Name, jobTitle), cancellationToken);
        _logger.LogInformation($"User with ID: '{user.Id}' has signed up.");
    }
}