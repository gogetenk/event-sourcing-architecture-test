using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YtDeveloppement.EventSourcing.Orders.Domain.Events;

namespace YtDeveloppement.EventSourcing.Orders.Domain.Abstractions
{
    public interface IEventStore : IDisposable
    {
        Task RecordAsync(EventBase eventBase);
        Task CommitChanges();
    }
}
