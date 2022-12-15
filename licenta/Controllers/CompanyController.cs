using Microsoft.AspNetCore.Mvc;

namespace licenta.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
