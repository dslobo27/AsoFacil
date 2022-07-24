using Microsoft.AspNetCore.Mvc;

namespace AsoFacil.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}