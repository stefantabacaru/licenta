using licenta.Interfaces.Services;
using licenta.Models.EmployeeRoute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace licenta.Services
{
    public class EmployeeRouteService : IEmployeeRouteService
    {
        public Task<int> CreateEmployeeRoute(EmployeeRoute employeeRoute)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeRoute> GetEmployeeRoute()
        {
            throw new NotImplementedException();
        }

        public Task<List<int>> GetEmployeesByRouteId(int reouteId)
        {
            throw new NotImplementedException();
        }

        public Task<List<int>> GetRoutesEmployeeId(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
