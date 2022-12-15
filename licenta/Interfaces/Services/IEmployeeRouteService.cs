using licenta.Models.CarsRoute;
using licenta.Models.EmployeeRoute;
using System.Threading.Tasks;

namespace licenta.Interfaces.Services
{
    public interface IEmployeeRouteService
    {
        public Task<int> CreateEmployeeRoute(EmployeeRoute employeeRoute);

        public Task<EmployeeRoute> GetEmployeeRoute();
    }
}
