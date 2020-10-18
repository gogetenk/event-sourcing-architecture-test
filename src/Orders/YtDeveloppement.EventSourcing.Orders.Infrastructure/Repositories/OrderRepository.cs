using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YtDeveloppement.EventSourcing.Microservices.Orders.Domain.Dtos;
using YtDeveloppement.EventSourcing.Orders.Domain.Abstractions;

namespace YtDeveloppement.EventSourcing.Orders.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public Task<List<OrderDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto> InsertAsync(OrderDto customer)
        {
            throw new NotImplementedException();
        }
    }
}
