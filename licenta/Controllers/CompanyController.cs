using AutoMapper;
using licenta.DtoModels.Company;
using licenta.Interfaces.Services;
using licenta.Models.Company;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace licenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;
        private readonly IMapper mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            this.companyService = companyService ?? throw new ArgumentNullException(nameof(companyService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetCompany()
        {
            return Ok(await companyService.GetCompany().ConfigureAwait(false));
        }

        [HttpPost]
        [Route("post")]
        public async Task<IActionResult> CreateCompany(CompanyGetDto companyDto)
        {
            var company = mapper.Map<CompanyGet>(companyDto);
            await companyService.CreateCompany(company).ConfigureAwait(false);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/1",
                company);
        }
    }
}
