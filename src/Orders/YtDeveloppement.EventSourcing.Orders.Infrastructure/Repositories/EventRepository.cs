using System.Threading.Tasks;
using MongoDB.Driver;
using YtDeveloppement.EventSourcing.Orders.Domain.Abstractions;
using YtDeveloppement.EventSourcing.Orders.Domain.Events;

namespace YtDeveloppement.EventSourcing.Orders.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly IMongoDatabase _db;

        public EventRepository(string connectionString)
        {
            var client = new MongoClient(connectionString);
            _db = client.GetDatabase("event-store");
        }

        public async Task RecordAsync(EventBase eventBase)
        {
            var collection = _db.GetCollection<EventBase>("events");
            await collection.InsertOneAsync(eventBase);
        }
    }
}
