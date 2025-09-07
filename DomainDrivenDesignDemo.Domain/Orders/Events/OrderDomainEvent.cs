using MediatR;

namespace DomainDrivenDesignDemo.Domain.Orders;

public sealed class OrderDomainEvent : INotification
{
    public Order Order { get; }

    public OrderDomainEvent(Order order)
    {
        Order = order;
    }
}