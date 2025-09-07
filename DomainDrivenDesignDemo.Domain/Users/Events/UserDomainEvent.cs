using MediatR;

namespace DomainDrivenDesignDemo.Domain.Users;

public sealed class UserDomainEvent : INotification
{
    public User User { get; }

    public UserDomainEvent(User user)
    {
        User = user;
    }
}