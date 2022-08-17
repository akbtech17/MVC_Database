using Microsoft.AspNetCore.Mvc;
using MVC_Database.Models;

namespace MVC_Database.Controllers
{
    public class DeptController : Controller
    {
        IDept repos;
        public DeptController(IDept _repos) { 
               repos = _repos;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
