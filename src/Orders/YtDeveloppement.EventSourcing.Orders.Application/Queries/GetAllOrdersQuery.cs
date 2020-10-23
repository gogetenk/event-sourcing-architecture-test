using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using YtDeveloppement.EventSourcing.Microservices.Orders.Domain.Dtos;
using YtDeveloppement.EventSourcing.Orders.Domain.Abstractions;

namespace YtDeveloppement.EventSourcing.Microservices.Orders.Application.Queries
{
    public class GetAllOrdersQuery : IRequest<List<OrderDto>>
    {
        public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, List<OrderDto>>
        {
            private readonly IReadOrderRepository _orderRepository;

            public GetAllOrdersHandler(IReadOrderRepository orderRepository)
            {
                _orderRepository = orderRepository;
            }

            public async Task<List<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
            {
                return await _orderRepository.GetAllAsync();
            }
        }
    }
}
