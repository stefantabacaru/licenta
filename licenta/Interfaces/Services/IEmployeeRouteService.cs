using licenta.Models.Employee;
using licenta.Models.EmployeeRoute;
using licenta.Models.Routes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace licenta.Interfaces.Services
{
    public interface IEmployeeRouteService
    {
        public Task<int> CreateEmployeeRoute(EmployeeRoute employeeRoute);

        public Task<List<EmployeeRoute>> GetEmployeeRoute();

       public Task<List<RoutesGet>> GetRoutesEmployeeId(int employeeId);

       public Task<List<EmployeeGet>> GetEmployeesByRouteId(int routeId);
    }
}
