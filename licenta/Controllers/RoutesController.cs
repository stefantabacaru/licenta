using AutoMapper;
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
        private readonly IEmployeeRouteService employeeRouteService;
        private readonly IRoutesService routesService;
        private readonly ICarsRouteService carsRouteService;
        private readonly IMapper mapper;

        public RoutesController(IEmployeeRouteService employeeRouteService, IRoutesService routesService, IMapper mapper, ICarsRouteService carsRouteService)
        {
            this.carsRouteService = carsRouteService ?? throw new ArgumentNullException(nameof(carsRouteService));
            this.routesService = routesService ?? throw new ArgumentNullException(nameof(routesService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("getByCarId/{id}")]
        public async Task<IActionResult> GetRoutesByCarId(int carId)
        {
            return Ok(await carsRouteService.GetRoutesByCarId(carId).ConfigureAwait(false));
        }

        [HttpGet]
        [Route("getByEmployeeId/{id}")]
        public async Task<IActionResult> GetRoutesByEmployeeId(int employeeId)
        {
            return Ok(await employeeRouteService.GetRoutesEmployeeId(employeeId).ConfigureAwait(false));
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
