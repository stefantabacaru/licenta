using steptrans.Models.Employee;
using System.Threading.Tasks;

namespace steptrans.Interfaces.Services
{
    public interface IEmployeeService
    {
        public Task<int> CreateEmployee(EmployeeSave employeeSave);

        public Task<EmployeeSave> GetEmployees();
    }
}
