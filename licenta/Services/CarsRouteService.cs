using licenta.Interfaces.Services;
using licenta.Models.Cars;
using licenta.Models.CarsRoute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace licenta.Services
{
    public class CarsRouteService : ICarsRouteService
    {
        public Task<int> CreateCarsRoute(CarsRoute carsRoute)
        {
            throw new NotImplementedException();
        }

        public Task<List<CarsGet>> GetCarsByRouteId(int reouteId)
        {
            throw new NotImplementedException();
        }

        public Task<CarsRoute> GetCarsRoute()
        {
            throw new NotImplementedException();
        }

        public Task<List<int>> GetRoutesByCarId(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
