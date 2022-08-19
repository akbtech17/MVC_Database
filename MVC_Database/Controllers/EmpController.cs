using Microsoft.AspNetCore.Mvc;
using MVC_Database.Models;

namespace MVC_Database.Controllers
{
    public class EmpController : Controller
    {
        db1045Context db = new db1045Context();
        public IActionResult List()
        {
            return View();
        }
    }
}
