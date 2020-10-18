using System.Collections.Generic;
using System.Threading.Tasks;
using YtDeveloppement.EventSourcing.Customers.Model;

namespace YtDeveloppement.EventSourcing.Customers.Dal.Impl
{
    public class CustomerRepository : ICustomerRepository
    {
        public Task<List<Customer>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Customer> GetByIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task InsertAsync(Customer customer)
        {
            throw new System.NotImplementedException();
        }
    }
}
