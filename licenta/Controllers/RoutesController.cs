using AutoMapper;
using licenta.DtoModels;
using licenta.DtoModels.Routes;
using licenta.Interfaces.Services;
using licenta.Models.Routes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace licenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly IRoutesService routesService;
        private readonly IMapper mapper;

        public RoutesController( IRoutesService routesService, IMapper mapper)
        {
            this.routesService = routesService ?? throw new ArgumentNullException(nameof(routesService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetRoutes()
        {
            return Ok(await routesService.GetRoutes().ConfigureAwait(false));
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetRouteById(int id)
        {
            var route = await routesService.GetRouteById(id).ConfigureAwait(false);
            if (route != null)
            {
                return Ok(route);
            }

            return NotFound($"cant find route with the id: {id}");
        }

        [HttpGet]
        [Route("SearchRoute/{Destination}/{Departure}/{Day}/{PasNumbers}")]
        public async Task<IActionResult> GetRoutesByDate(string Destination, string Departure, DateTime Day, int PasNumbers)
        {

            var searchRoute = new SearchRoute();
            searchRoute.PasNumbers = PasNumbers;
            searchRoute.Destination = Destination;
            searchRoute.Departure = Departure;
            searchRoute.Day = Day;
            var route = await routesService.SearchRoute(searchRoute).ConfigureAwait(false);

            return Ok(route);

        }

        [HttpPost]
        [Route("post")]
        public async Task<IActionResult> CreateRoute(RoutesSaveDto routeDto)
        {
            var route = mapper.Map<RoutesSave>(routeDto);
            var routeId = await routesService.CreateRoutes(route).ConfigureAwait(false);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + routeId,
                route);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteRouteById(int id)
        {
            await routesService.DeleteRouteById(id).ConfigureAwait(false);
            return Ok();
        }

        [HttpPatch]
        [Route("edit/{id}")]
        public async Task<IActionResult> EditCar(int id, RouteUpdateDto routeDto)
        {
            var route = mapper.Map<RoutesUpdate>(routeDto);
            await routesService.UpdateRoute(route, id).ConfigureAwait(false);
            return Ok();
        }


    }
}
