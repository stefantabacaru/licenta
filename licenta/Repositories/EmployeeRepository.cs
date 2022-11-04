using steptrans.Interfaces.Repositories;
using steptrans.Models.Employee;

namespace steptrans.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Task<EmployeeSave> CreateEmployee(EmployeeSave employeeSave)
        {
            throw new NotImplementedException();
        }
    }
}
