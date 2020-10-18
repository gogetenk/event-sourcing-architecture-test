using System.Collections.Generic;
using System.Threading.Tasks;
using YtDeveloppement.EventSourcing.Customers.Model;

namespace YtDeveloppement.EventSourcing.Customers.Dal
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(string id);
        Task<List<Customer>> GetAllAsync();
        Task InsertAsync(Customer customer);
    }
}
