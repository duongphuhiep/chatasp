using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dal;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public string Index(string name)
        {
            return "Hello World";
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
