using Microsoft.AspNetCore.Mvc;

namespace MVC_Database.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int a = 10, b = 0;
            int c = a / b;
            return View();
        }
    }
}
