using System;

namespace YtDeveloppement.EventSourcing.Orders.Domain.Events
{
    public class EventBase
    {
        public DateTime TimeOccured { get; set; }
    }
}
