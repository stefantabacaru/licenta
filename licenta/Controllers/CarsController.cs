using licenta.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace licenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarsService carsService;
    }
}
