using AutoMapper;
using licenta.DAOModels;
using licenta.Interfaces.Services;
using licenta.Models.Employee;
using licenta.Models.EmployeeRoute;
using licenta.Models.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace licenta.Services
{
    public class EmployeeRouteService : IEmployeeRouteService
    {

        private Context.ContextDB _context;
        private readonly IMapper mapper;

        public EmployeeRouteService(Context.ContextDB context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<int> CreateEmployeeRoute(EmployeeRoute employeeRoute)
        {
            var carsRouteDao = mapper.Map<EmployeeRouteDao>(employeeRoute);
            _context.EmployeeRoutes.Add(carsRouteDao);
            _context.SaveChanges();
            return carsRouteDao.Id;
        }

        public async Task<List<EmployeeRoute>> GetEmployeeRoute()
        {
            return mapper.Map<List<EmployeeRoute>>(_context.EmployeeRoutes.ToList());
        }

        public async Task<List<EmployeeGet>> GetEmployeesByRouteId(int routeId)
        {
   
            var Employees = from c in _context.EmployeeRoutes
                            where (c.RouteId == routeId)
                            select c.Employee;

            return mapper.Map<List<EmployeeGet>>(Employees.ToList());
        }

        public async  Task<List<RoutesGet>> GetRoutesEmployeeId(int employeeId)
        {
            var Routes = from c in _context.EmployeeRoutes
                         where (c.RouteId == employeeId)
                         select c.Route;

            return mapper.Map<List<RoutesGet>>(Routes.ToList());
        }
    }
}
