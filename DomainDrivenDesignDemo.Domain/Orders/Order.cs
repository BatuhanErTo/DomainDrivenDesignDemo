using DomainDrivenDesignDemo.Domain.Abstractions;
using DomainDrivenDesignDemo.Domain.Shared;

namespace DomainDrivenDesignDemo.Domain.Orders;

public sealed class Order : Entity
{
    private Order(Guid id) : base(id) { }

    public Order(Guid id, string orderNumber, DateTime createdDate, OrderStatusEnum status) : base(id)
    {
        OrderNumber = orderNumber;
        CreatedDate = createdDate;
        Status = status;
    }

    public string OrderNumber { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public OrderStatusEnum Status { get; private set; }
    public ICollection<OrderLine> OrderLine { get; private set; }

    public void CreateOrder(ICollection<CreateOrderDto> createOrderDtos)
    {
        foreach (var item in createOrderDtos)
        {
            if (item.Quantity < 1)
            {
                throw new ArgumentException("Selected Quantity cannot be zero or less!!");
            }

            OrderLine orderLine = new OrderLine(
                Guid.NewGuid(),
                Id,
                item.ProductId,
                item.Quantity,
                new(item.Amount, Currency.FromCode(item.Currency))
            );
            OrderLine.Add(orderLine);
        }
    }

    public void RemoveOrderLine(Guid orderLineId)
    {
        var orderLine = OrderLine.FirstOrDefault(element => element.Id == orderLineId) ?? null;
        if (orderLine is null)
        {
            throw new ArgumentException("Selected Order Line to be removed cannot be null!");
        }
        OrderLine.Remove(orderLine);
    }
}