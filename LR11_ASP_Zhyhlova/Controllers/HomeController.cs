using Microsoft.AspNetCore.Mvc;

namespace LR11_ASP_Zhyhlova.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Feedback()
        {
            return View();
        }
    }
}
