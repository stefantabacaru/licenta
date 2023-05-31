using AutoMapper;
using licenta.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using licenta.DtoModels.Employee;
using licenta.Models.Employee;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace licenta.Controllers
{
    [ApiController]
    [Route("Employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRouteService employeeRouteService;
        private readonly IEmployeeService employeeService;
        private readonly IMapper mapper;

        public EmployeeController(IEmployeeRouteService employeeRouteService, IEmployeeService employeeService, IMapper mapper)
        {
            this.employeeRouteService = employeeRouteService ?? throw new ArgumentNullException(nameof(employeeRouteService));

            this.employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPatch]
        [Route("editPassword/{newPassword}")]
        public async Task<IActionResult> editPassword(int id, string oldPassword, string newPassword)
        {
            try
            {
                await employeeService.editPassword(id, oldPassword, newPassword).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Wrong password");
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(string username, string password)
        {

            var token = await employeeService.Login(username, password).ConfigureAwait(false);
            return Ok(token);
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetEmployees()
        {
            return Ok(await employeeService.GetEmployees().ConfigureAwait(false));
        }

        [HttpGet]
        [Route("getByRouteId/{id}")]
        public async Task<IActionResult> GetemployeeByRouteId(int routeId)
        {
            return Ok(await employeeRouteService.GetEmployeesByRouteId(routeId).ConfigureAwait(false));
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await employeeService.GetEmployeeById(id).ConfigureAwait(false);
            if (employee != null)
            {
                return Ok(employee);
            }

            return NotFound($"cant find employee with the id: {id}");
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateEmployee(EmployeeSaveDto employeeSaveDto)
        {
            try
            {
                var employeeSave = mapper.Map<EmployeeSave>(employeeSaveDto);
                var employeeId = await employeeService.CreateEmployee(employeeSave, employeeSaveDto.Password).ConfigureAwait(false);

                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employeeId, employeeId);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteEmployeeById(int id)
        {
            await employeeService.DeleteEmployeeById(id).ConfigureAwait(false);
            return Ok();
        }

        [HttpPatch]
        [Route("edit/{id}")]
        public async Task<IActionResult> EditEmployee(int id, EmployeeUpdateDto employeeDto)
        {
            var employee = mapper.Map<EmployeeUpdate>(employeeDto);
            await employeeService.UpdateEmployee(employee, id).ConfigureAwait(false);
            return Ok();
        }

      
    }
}
