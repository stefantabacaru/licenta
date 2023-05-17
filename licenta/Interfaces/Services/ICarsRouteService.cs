using licenta.Models.Cars;
using licenta.Models.CarsRoute;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace licenta.Interfaces.Services
{
    public interface ICarsRouteService
    {
        public Task<int> CreateCarsRoute(CarsRoute carsRoute);

        public Task<CarsRoute> GetCarsRoute();

        public Task<List<int>> GetRoutesByCarId(int carId);

        public Task<List<CarsGet>> GetCarsByRouteId(int reouteId);
    }
}
