using licenta.Models.EmployeeRoute;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace licenta.Interfaces.Services
{
    public interface IEmployeeRouteService
    {
        public Task<int> CreateEmployeeRoute(EmployeeRoute employeeRoute);

        public Task<EmployeeRoute> GetEmployeeRoute();

       public Task<List<int>> GetRoutesEmployeeId(int employeeId);

       public Task<List<int>> GetEmployeesByRouteId(int reouteId);
    }
}
