using licenta.Interfaces.Services;
using licenta.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace licenta.Services
{
    public class CustomerService : ICustomerService
    {
        public Task<int> CreateCustomer(CustomerSave customerSave)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerGet> GetCustomer()
        {
            throw new NotImplementedException();
        }
    }
}
