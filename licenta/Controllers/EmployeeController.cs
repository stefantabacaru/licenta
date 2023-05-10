using AutoMapper;
using licenta.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using licenta.DtoModels.Employee;
using licenta.Models.Employee;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace licenta.Controllers
{
    [ApiController]
    [Route("Employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        private readonly IMapper mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            this.employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetEmployees()
        {
            return Ok(await employeeService.GetEmployees().ConfigureAwait(false));
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateEmployee(EmployeeSaveDto employeeSaveDto)
        {
            try
            {
                var employeeSave = mapper.Map<EmployeeSave>(employeeSaveDto);
                var employeeId = await employeeService.CreateEmployee(employeeSave).ConfigureAwait(false);

                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employeeId, employeeId);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
