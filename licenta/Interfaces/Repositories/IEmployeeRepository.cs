using steptrans.Models.Employee;
using System.Threading.Tasks;

namespace steptrans.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<int> CreateEmployee(EmployeeSave employeeSave);
    }
}
