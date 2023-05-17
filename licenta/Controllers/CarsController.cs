using AutoMapper;
using licenta.DtoModels.Cars;
using licenta.Interfaces.Services;
using licenta.Models.Cars;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace licenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarsService carsService;
        private readonly ICarsRouteService carsRouteService;
        private readonly IMapper mapper;

        public CarsController(ICarsService carsService, IMapper mapper, ICarsRouteService carsRouteService)
        {
            this.carsRouteService = carsRouteService ?? throw new ArgumentNullException(nameof(carsRouteService));
            this.carsService = carsService ?? throw new ArgumentNullException(nameof(carsService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("getByRouteId/{id}")]
        public async Task<IActionResult> GetCarsByRouteId(int routeId)
        {
            return Ok(await carsRouteService.GetCarsByRouteId(routeId).ConfigureAwait(false));
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetCars()
        {
            return Ok(await carsService.GetCars().ConfigureAwait(false));
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var car = await carsService.GetCarById(id).ConfigureAwait(false);
            if (car != null)
            {
                return Ok(car);
            }

            return NotFound($"cant find car with the id: {id}");
        }

        [HttpPost]
        [Route("post")]
        public async Task<IActionResult> CreateCar(CarsSaveDto carDto)
        {
            var car = mapper.Map<CarsSave>(carDto);
            var carId = await carsService.CreateCars(car).ConfigureAwait(false);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + carId,
                car);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteCarById(int id)
        {
            await carsService.DeleteCarById(id).ConfigureAwait(false);
            return Ok();
        }

        [HttpPatch]
        [Route("edit/{id}")]
        public async Task<IActionResult> EditCar(int id, CarsUpdateDto carDto)
        {
             var car = mapper.Map<CarsUpdate>(carDto);
             await carsService.UpdateCars(car, id).ConfigureAwait(false);
             return Ok();
        }
    }
}
