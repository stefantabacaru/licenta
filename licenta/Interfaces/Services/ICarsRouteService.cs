using licenta.Models.Cars;
using licenta.Models.CarsRoute;
using licenta.Models.Routes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace licenta.Interfaces.Services
{
    public interface ICarsRouteService
    {
        public Task<int> CreateCarsRoute(CarsRoute carsRoute);

        public Task<List<CarsRoute>> GetCarsRoute();

        public Task<List<RoutesGet>> GetRoutesByCarId(int carId);

        public Task<List<CarsGet>> GetCarsByRouteId(int routeId);
    }
}
