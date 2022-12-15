using Microsoft.AspNetCore.Mvc;

namespace licenta.Controllers
{
    public class CarsRouteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
