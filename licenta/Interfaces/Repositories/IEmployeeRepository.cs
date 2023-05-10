using licenta.Models.Employee;
using System.Threading.Tasks;

namespace licenta.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<int> CreateEmployee(EmployeeSave employeeSave);
    }
}
