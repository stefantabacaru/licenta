using AutoMapper;
using licenta.DAOModels;
using licenta.Interfaces.Services;
using licenta.Models.Cars;
using licenta.Models.CarsRoute;
using licenta.Models.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace licenta.Services
{
    public class CarsRouteService : ICarsRouteService
    {
        private Context.ContextDB _context;
        private readonly IMapper mapper;

        public CarsRouteService(Context.ContextDB context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<int> CreateCarsRoute(CarsRoute carsRoute)
        {
            var carsRouteDao = mapper.Map<CarsRouteDao>(carsRoute);
            _context.CarsRoutes.Add(carsRouteDao);
            _context.SaveChanges();
            return carsRouteDao.Id;
        }

        public async Task<List<CarsGet>> GetCarsByRouteId(int routeId)
        {
            var Cars = from c in _context.CarsRoutes
                       where (c.RouteId == routeId)
                       select c.Car;

            return mapper.Map<List<CarsGet>>(Cars.ToList());
        }

        public async Task<List<CarsRoute>> GetCarsRoute()
        {
            return mapper.Map<List<CarsRoute>>(_context.CarsRoutes.ToList());
        }

        public async  Task<List<RoutesGet>> GetRoutesByCarId(int carId)
        {
            var Routes = from c in _context.CarsRoutes
                       where (c.RouteId == carId)
                       select c.Route;

            return mapper.Map<List<RoutesGet>>(Routes.ToList());
        }
    }
}
