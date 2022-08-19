using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Database.Models;
using System.Linq;

namespace MVC_Database.Controllers
{
    public class EmpController : Controller
    {
        db1045Context db = new db1045Context();
        public IActionResult List()
        {
            var empdata = db.Emps.Include("Dept").ToList();
            return View(empdata);
        }
    }
}
