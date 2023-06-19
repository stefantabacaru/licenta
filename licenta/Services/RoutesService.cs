using AutoMapper;
using licenta.DAOModels;
using licenta.DtoModels;
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
        private Context.ContextDB _context;
        private readonly IMapper mapper;

        public RoutesService(Context.ContextDB context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<int> CreateRoutes(RoutesSave routesSave)
        {
            var routeSaveDao = mapper.Map<RoutesDao>(routesSave);
            _context.Routes.Add(routeSaveDao);
            _context.SaveChanges();
            return routeSaveDao.RouteId;
        }

        public async Task DeleteRouteById(int id)
        {
            var route = _context.Routes.SingleOrDefault(x => x.RouteId == id);
            _context.Routes.Remove(route);
            _context.SaveChanges();
        }

        public async Task<RoutesGet> GetRouteById(int id)
        {
            return mapper.Map<RoutesGet>(_context.Routes.SingleOrDefault(x => x.RouteId == id));
        }

        public async Task<List<RoutesGet>> GetRoutes()
        {
            return mapper.Map<List<RoutesGet>>(_context.Routes.ToList());
        }

        public async Task UpdateRoute(RoutesUpdate routesUpdate, int id)
        {
            var route = _context.Routes.SingleOrDefault(x => x.RouteId == id);
            if (routesUpdate != null)
            {
                route.CollectedMoney = routesUpdate.CollectedMoney;
                route.SpentMoney = routesUpdate.SpentMoney;
                route.KmNumber = routesUpdate.KmNumber;
                route.PassengersNumber = routesUpdate.PassengersNumber;
                route.RouteDetails = routesUpdate.RouteDetails;
                route.RoutePeriod = routesUpdate.RoutePeriod;
                
                _context.Routes.Update(route);
                _context.SaveChanges();
            }
        }

        public async Task<List<RoutesGet>> SearchRoute(SearchRoute searchRoute)
        {
            var list = _context.Routes.Where(x => x.RoutePeriod.DayOfYear == searchRoute.Day.DayOfYear && (x.RouteDestination == searchRoute.Destination) && x.RouteDeparture == searchRoute.Departure && x.RouteCar.SeatsNumber - x.PassengersNumber >= searchRoute.PasNumbers);
            var listFinal = mapper.Map<List<RoutesGet>>(list);
            return listFinal;
        }
    }
}
