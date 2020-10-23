using System.Threading;
using System.Threading.Tasks;
using MediatR;
using YtDeveloppement.EventSourcing.Microservices.Orders.Domain.Dtos;
using YtDeveloppement.EventSourcing.Orders.Domain.Abstractions;

namespace YtDeveloppement.EventSourcing.Microservices.Orders.Application.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderDto>
    {
        public string Id { get; }

        public GetOrderByIdQuery(string id)
        {
            Id = id;
        }

        public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
        {
            private readonly IReadOrderRepository _orderRepository;

            public GetOrderByIdHandler(IReadOrderRepository orderRepository)
            {
                _orderRepository = orderRepository;
            }

            public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
            {
                return await _orderRepository.GetByIdAsync(request.Id);
            }
        }
    }
}
