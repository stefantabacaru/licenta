using licenta.Models.Routes;
using System.Threading.Tasks;

namespace licenta.Interfaces.Services
{
    public interface IRoutesService
    {
        public Task<int> CreateRoutes(RoutesSave routesSave);

        public Task<RoutesSave> GetRoutes();
    }
}
