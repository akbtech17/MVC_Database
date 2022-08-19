using Microsoft.AspNetCore.Mvc;
using MVC_Database.Models;

namespace MVC_Database.Controllers
{
    public class EmpController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
