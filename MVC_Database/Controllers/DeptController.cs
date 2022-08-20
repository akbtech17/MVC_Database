using Microsoft.AspNetCore.Mvc;
using MVC_Database.Models;
using System;

namespace MVC_Database.Controllers
{
    public class DeptController : Controller
    {
        IDept repos;
        public DeptController(IDept _repos) { 
               repos = _repos;
        }
        public IActionResult List()
        {
            var data = repos.GetDepts();
            return View(data);
        }

        public IActionResult Display(int Id) {
            var data = repos.FindDept(Id);
            return View(data);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var data = repos.FindDept(Id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Delete(Dept dept) {
            repos.DeleteDept(dept.Id);
            var data = repos.GetDepts();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Dept dept)
        {
            try {
                if (ModelState.IsValid)
                {
                    repos.AddDept(dept);
                    return RedirectToAction("List");
                }
                return View(dept);
            }

            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var data = repos.FindDept(Id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Dept dept)
        {
            if (ModelState.IsValid)
            {
                repos.EditDept(dept);
                return RedirectToAction("List");
            }
            return View(dept);
        }
    }
}
