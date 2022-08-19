using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.DeptId = new SelectList(db.Depts, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Emp emp)
        {
            if (ModelState.IsValid) { 
                db.Emps.Add(emp);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            ViewBag.DeptId = new SelectList(db.Depts, "Id", "Name");
            return View(emp);
        }
    }
}
