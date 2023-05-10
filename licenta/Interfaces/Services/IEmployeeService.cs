using licenta.Models.Employee;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace licenta.Interfaces.Services
{
    public interface IEmployeeService
    {
        public Task CreateEmployee(EmployeeSave employeeSave);

        public Task<List<EmployeeGet>> GetEmployees();

        public Task<EmployeeGet> GetEmployeeById(int id);

        public Task UpdateEmployee(EmployeeUpdate employeeUpdate);

        public Task DeleteEmployeeById(int id);
    }
}
