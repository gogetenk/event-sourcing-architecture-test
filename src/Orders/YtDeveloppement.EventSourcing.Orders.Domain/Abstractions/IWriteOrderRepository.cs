using System.Threading.Tasks;
using YtDeveloppement.EventSourcing.Microservices.Orders.Domain.Dtos;

namespace YtDeveloppement.EventSourcing.Orders.Domain.Abstractions
{
    public interface IWriteOrderRepository
    {
        Task<OrderDto> InsertAsync(OrderDto customer);
    }
}
