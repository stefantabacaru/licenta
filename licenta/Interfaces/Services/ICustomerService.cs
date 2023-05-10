using licenta.Models.Customer;
using System.Threading.Tasks;

namespace licenta.Interfaces.Services
{
    public interface ICustomerService
    {
        public Task CreateCustomer(CustomerSave customerSave);

        public Task<CustomerGet> GetCustomer();
    }
}
