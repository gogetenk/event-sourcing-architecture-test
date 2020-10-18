using YtDeveloppement.EventSourcing.Microservices.Orders.Domain.Dtos;

namespace YtDeveloppement.EventSourcing.Orders.Domain.Events
{
    public class OrderAddedEvent : EventBase
    {
        public OrderDto Target { get; set; }

        public OrderAddedEvent(OrderDto target)
        {
            Target = target;
        }
    }
}
