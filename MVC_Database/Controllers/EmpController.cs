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
            ViewBag.Deptid = new SelectList(db.Depts, "Id", "Name");
            return View(emp);
        }

        [HttpGet]
        public IActionResult Edit(int id) {
            var empdata = db.Emps.Find(id);
            ViewBag.Deptid = new SelectList(db.Depts, "Id", "Name");
            return View(empdata);
        }

        [HttpPost]
        public IActionResult Edit(Emp emp)
        {
            if (ModelState.IsValid) {
                var odata = db.Emps.Find(emp.Id);
                odata.Name = emp.Name;
                odata.Salary = emp.Salary;
                odata.Email = emp.Email;
                odata.Dob = emp.Dob;
                odata.Deptid = emp.Deptid;
                db.SaveChanges();
                return RedirectToAction("List");
            }
           
            ViewBag.Deptid = new SelectList(db.Depts, "Id", "Name");
            return View(emp);
        }
    }
}
