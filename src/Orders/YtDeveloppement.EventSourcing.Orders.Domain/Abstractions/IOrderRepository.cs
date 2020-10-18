using System.Collections.Generic;
using System.Threading.Tasks;
using YtDeveloppement.EventSourcing.Microservices.Orders.Domain.Dtos;

namespace YtDeveloppement.EventSourcing.Orders.Domain.Abstractions
{
    public interface IOrderRepository
    {
        Task<OrderDto> GetByIdAsync(string id);
        Task<List<OrderDto>> GetAllAsync();
        Task<OrderDto> InsertAsync(OrderDto customer);
    }
}
