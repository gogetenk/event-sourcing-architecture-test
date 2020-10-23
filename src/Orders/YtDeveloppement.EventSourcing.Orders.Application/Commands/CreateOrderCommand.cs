using System.Threading;
using System.Threading.Tasks;
using MediatR;
using YtDeveloppement.EventSourcing.Microservices.Orders.Domain.Dtos;
using YtDeveloppement.EventSourcing.Orders.Domain.Abstractions;

namespace YtDeveloppement.EventSourcing.Microservices.Orders.Application.Commands
{
    public class CreateOrderCommand : IRequest<OrderDto>
    {
        public OrderDto Order { get; set; }

        public CreateOrderCommand(OrderDto order)
        {
            Order = order;
        }

        public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, OrderDto>
        {
            private readonly IWriteOrderRepository _orderRepository;

            public CreateOrderHandler(IWriteOrderRepository orderRepository)
            {
                _orderRepository = orderRepository;
            }

            public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
            {
                return await _orderRepository.InsertAsync(request.Order);
            }
        }
    }
}
