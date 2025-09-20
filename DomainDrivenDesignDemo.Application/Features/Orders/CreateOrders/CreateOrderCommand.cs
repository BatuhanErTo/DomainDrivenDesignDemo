using DomainDrivenDesignDemo.Domain.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesignDemo.Application.Features.Orders.CreateOrders
{
    public sealed record CreateOrderCommand(List<CreateOrderDto> CreateOrderDtos) : IRequest;
}
