using licenta.DtoModels;
using licenta.Models.Routes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace licenta.Interfaces.Services
{
    public interface IRoutesService
    {
        public Task<int> CreateRoutes(RoutesSave routesSave);

        public Task<List<RoutesGet>> GetRoutes();

        public Task<RoutesGet> GetRouteById(int id);

        public Task UpdateRoute(RoutesUpdate routesUpdate, int id);

        public Task DeleteRouteById(int id);

        public Task<List<RoutesGet>> SearchRoute(SearchRoute searchRoute);
        
    }
}
