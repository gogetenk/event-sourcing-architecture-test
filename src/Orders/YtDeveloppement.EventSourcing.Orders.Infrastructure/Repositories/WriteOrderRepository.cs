using System.Threading.Tasks;
using MongoDB.Driver;
using YtDeveloppement.EventSourcing.Microservices.Orders.Domain.Dtos;
using YtDeveloppement.EventSourcing.Orders.Domain.Abstractions;

namespace YtDeveloppement.EventSourcing.Orders.Infrastructure.Repositories
{
    public class WriteOrderRepository : IWriteOrderRepository
    {
        private readonly IMongoDatabase _db;

        public WriteOrderRepository(string connectionString)
        {
            var client = new MongoClient(connectionString);
            _db = client.GetDatabase("orders-commands");
        }

        public async Task<OrderDto> InsertAsync(OrderDto customer)
        {
            var collection = _db.GetCollection<OrderDto>("orders");
            await collection.InsertOneAsync(customer);
            return customer;
        }
    }
}
