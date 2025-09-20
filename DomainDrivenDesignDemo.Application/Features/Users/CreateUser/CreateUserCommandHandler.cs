using DomainDrivenDesignDemo.Application.Features.Users.CreateUser;
using DomainDrivenDesignDemo.Domain.Users;
using MediatR;

internal sealed class CreateUserCommandHander : IRequestHandler<CreateUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;

    public CreateUserCommandHander(IUserRepository userRepository, IUnitOfWork unitOfWork, IMediator mediator)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mediator = mediator;
    }

    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.CreateAsync(
            request.Name,
            request.Email,
            request.Password,
            request.Country,
            request.City,
            request.Street,
            request.FullAdress,
            request.PostalCode,
            cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        await _mediator.Publish(new UserDomainEvent(user));
    }
}
