using steptrans.Models.Employee;

namespace steptrans.Interfaces.Services
{
    public interface IEmployeeService
    {
        public Task<EmployeeSave> CreateEmployee(EmployeeSave employeeSave);
    }
}
