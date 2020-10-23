using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using YtDeveloppement.EventSourcing.Microservices.Orders.Domain.Dtos;
using YtDeveloppement.EventSourcing.Orders.Domain.Abstractions;

namespace YtDeveloppement.EventSourcing.Orders.Infrastructure.Repositories
{
    public class ReadOrderRepository : IReadOrderRepository
    {
        private readonly IMongoDatabase _db;

        public ReadOrderRepository(string connectionString)
        {
            var client = new MongoClient(connectionString);
            _db = client.GetDatabase("orders-queries");
        }

        public async Task<List<OrderDto>> GetAllAsync()
        {
            var collection = _db.GetCollection<OrderDto>("orders");
            return await (await collection.FindAsync(x => true)).ToListAsync();
        }

        public async Task<OrderDto> GetByIdAsync(string id)
        {
            var collection = _db.GetCollection<OrderDto>("orders");
            return await (await collection.FindAsync(x => x.Id == id)).FirstOrDefaultAsync();
        }
    }
}
