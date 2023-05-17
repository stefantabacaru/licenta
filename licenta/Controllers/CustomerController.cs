using AutoMapper;
using licenta.DtoModels.Customer;
using licenta.Interfaces.Services;
using licenta.Models.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace licenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        private readonly IMapper mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            this.customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetCustomer()
        {
            return Ok(await customerService.GetCustomer().ConfigureAwait(false));
        }

        [HttpPost]
        [Route("post")]
        public async Task<IActionResult> CreateCustomer(CustomerSaveDto customerDto)
        {
            var customer = mapper.Map<CustomerSave>(customerDto);
            var customerId  = await customerService.CreateCustomer(customer).ConfigureAwait(false);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + customerId,
                customer);
        }
    }
}
