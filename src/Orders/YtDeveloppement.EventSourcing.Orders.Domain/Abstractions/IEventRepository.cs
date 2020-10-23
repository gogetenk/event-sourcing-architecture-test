using System.Threading.Tasks;
using YtDeveloppement.EventSourcing.Orders.Domain.Events;

namespace YtDeveloppement.EventSourcing.Orders.Domain.Abstractions
{
    public interface IEventRepository
    {
        Task RecordAsync(EventBase eventBase);
    }
}
