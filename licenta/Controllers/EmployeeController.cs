using Microsoft.AspNetCore.Mvc;
using steptrans.Interfaces.Services;
using steptrans.Models.Employee;
using System.ComponentModel.DataAnnotations;

namespace steptrans.Controllers
{
    [ApiController]
    [Route("Employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        //private readonly IMapper mapper;

        //public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        //{
        //    this.employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        //    this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        //}

        //[HttpPost]
        //[Route("create")]
        //public async Task<IActionResult> CreateEmployee(EmployeeSaveDao employeeSaveDto)
        //{
        //    try
        //    {
        //        var employeeSave = mapper.Map<EmployeeSave>(employeeSaveDto);
        //        var employee = await employeeService.CreateEmployee(employeeSave).ConfigureAwait(false);

        //        return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id, employee);
    
        //}
        //    catch (ValidationException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
