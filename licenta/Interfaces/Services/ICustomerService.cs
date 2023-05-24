using licenta.Models.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace licenta.Interfaces.Services
{
    public interface ICustomerService
    {
        public Task<int> CreateCustomer(CustomerSave customerSave);

        public Task<List<CustomerGet>> GetCustomer();
        public Task<CustomerGet> GetCustomerById(int id);

        public Task<List<CustomerGet>> GetCustomerByRouteId(int id);
    }
}
