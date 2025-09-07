using MediatR;

namespace DomainDrivenDesignDemo.Domain.Orders;

public sealed class SendOrderEmailEvent : INotificationHandler<OrderDomainEvent>
{
    public Task Handle(OrderDomainEvent notification, CancellationToken cancellationToken)
    {
        // email send logic
        return Task.CompletedTask;
    }
}