using steptrans.Models.Employee;

namespace steptrans.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<EmployeeSave> CreateEmployee(EmployeeSave employeeSave);
    }
}
