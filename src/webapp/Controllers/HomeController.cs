using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dal;
using Microsoft.AspNetCore.Mvc;
using Dal;
using Dal.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index(bool bye)
        {
            ViewData[Global.BYE] = bye;
            return View();
        }

        [Authorize(Policy = nameof(Global.LOGGED_USER_ONLY))]
        public async Task<ViewResult> IndexLogged()
        {
            var principal = await HttpContext.Authentication.AuthenticateAsync(Global.BASIC_AUTH_COOKIE);
            var emailClaim = principal.FindFirst(nameof(Dal.Model.User.Email));
            var email = emailClaim.Value;
            var user = await UserStore.FindUser(email);
            return View("IndexLogged", user);
        }

        public string About()
        {
            return "About";
        }
        public string Contact()
        {
            return "Contact";
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
