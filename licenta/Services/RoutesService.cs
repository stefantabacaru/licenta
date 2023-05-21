using licenta.Interfaces.Services;
using licenta.Models.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace licenta.Services
{
    public class RoutesService : IRoutesService
    {
        public Task<int> CreateRoutes(RoutesSave routesSave)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRouteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RoutesGet> GetRouteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<RoutesGet>> GetRoutes()
        {
            throw new NotImplementedException();
        }

        public Task UpdateRoute(RoutesUpdate routesUpdate, int id)
        {
            throw new NotImplementedException();
        }
    }
}
