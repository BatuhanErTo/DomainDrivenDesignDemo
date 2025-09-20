using DomainDrivenDesignDemo.Domain.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesignDemo.Application.Features.Orders.CreateOrders
{
    internal sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.CreateAsync(request.CreateOrderDtos, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new OrderDomainEvent(order));
        }
    }
}
