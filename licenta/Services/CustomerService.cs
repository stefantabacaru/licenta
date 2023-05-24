using AutoMapper;
using licenta.DAOModels;
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
        private Context.ContextDB _context;
        private readonly IMapper mapper;

        public CustomerService(Context.ContextDB context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public async Task<int> CreateCustomer(CustomerSave customerSave)
        {
            var customerSaveDao = mapper.Map<CustomerDao>(customerSave);
            _context.Customers.Add(customerSaveDao);
            _context.SaveChanges();
            return customerSaveDao.CustomerId;
        }

        public async Task<List<CustomerGet>> GetCustomer()
        {
            return mapper.Map<List<CustomerGet>>(_context.Customers.ToList());
        }

        public async Task<List<CustomerGet>> GetCustomerByRouteId(int id)
        {
            return mapper.Map<List<CustomerGet>>(_context.Customers.Where(x => x.CustomerRouteId == id).ToList());
        }

        public async Task<CustomerGet> GetCustomerById(int id)
        {
            return mapper.Map<CustomerGet>(_context.Customers.SingleOrDefault(x => x.CustomerId == id));
        }
    }
}
