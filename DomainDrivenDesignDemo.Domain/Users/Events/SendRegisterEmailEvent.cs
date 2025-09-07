using MediatR;

namespace DomainDrivenDesignDemo.Domain.Users;

public sealed class SendRegisterEmailEvent : INotificationHandler<UserDomainEvent>
{
    public Task Handle(UserDomainEvent notification, CancellationToken cancellationToken)
    {
        // email notification logic upon registration
        return Task.CompletedTask;
    }
}