using Microsoft.AspNetCore.Mvc;
using System;

namespace MVC_Database.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                int a = 10, b = 0;
                int c = a / b;
            }
            catch(Exception e) 
            {
                ViewBag.ErrorMessage = e.Message;
                return View("Error");
            }
            return View();
        }
    }
}