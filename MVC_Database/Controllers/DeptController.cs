using Microsoft.AspNetCore.Mvc;

namespace MVC_Database.Controllers
{
    public class DeptController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
