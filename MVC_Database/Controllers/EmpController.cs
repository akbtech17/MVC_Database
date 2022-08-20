using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Database.Models;
using System.Collections.Generic;
using System.Linq;
using MVC_Database.ViewModel;

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
                //odata.Email = emp.Email;
                odata.Dob = emp.Dob;
                odata.Deptid = emp.Deptid;
                db.SaveChanges();
                return RedirectToAction("List");
            }

            ViewBag.Deptid = new SelectList(db.Depts, "Id", "Name");
            return View(emp);
        }

        // remote validation
        public JsonResult EmailCheck(string Email) {

            bool found = db.Emps.Any(e => e.Email == Email);
            return Json(!found);
        }

        // action method for viewmodel
        public IActionResult ShowBonus() {
            List<Emp> emps = db.Emps.Include("Dept").ToList();
            List<EmpDept> empDepts = new List<EmpDept>();
            

            foreach (var data in emps)
            {
                EmpDept ed = new EmpDept();
                ed.Id = data.Id;
                ed.Name = data.Name;
                ed.DeptName = data.Dept.Name;
                ed.Location = data.Dept.Location;
                ed.Salary = data.Salary;

                if (data.Salary > 700000) ed.Bonus = 7000;
                else if (data.Salary > 400000) ed.Bonus = 4000;
                else ed.Bonus = 2000;

                empDepts.Add(ed);
              
            }
            return View(empDepts);
        }

        public IActionResult Display(int Id)
        {
            List<Emp> emps = db.Emps.Include("Dept").ToList();
            Emp emp = emps.Find(e => e.Id == Id);

            return View(emp);
        }
    
    }
}
