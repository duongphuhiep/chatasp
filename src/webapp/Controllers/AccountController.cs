using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using dal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Webapplication.Models.AccountViewModels;

namespace WebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger log;
        public AccountController(ILogger<AccountController> logger)
        {
            log = logger;
        }

        public async Task<IActionResult> Login(LoginStatusViewModel login)
        {
            log.LogInformation("SignIn", login);
            var authUser = await UserStore.Authenticate(login.Email, login.Password);
            if (authUser==null)
            {
                return View("Login");
            }

            #region build ClaimPrincipal

            var id = new ClaimsIdentity();
            id.AddClaims(new List<Claim>
            {
                new Claim(nameof(authUser.Email), authUser.Email),
                new Claim(nameof(authUser.NickName), authUser.NickName)
            });
            var principal = new ClaimsPrincipal(id);

            #endregion

            await HttpContext.Authentication.SignInAsync(Global.BASIC_AUTH_COOKIE, principal);

            return RedirectToAction("IndexLogged", "Home");
        }

        /// <summary>
        /// Redirect user to Home page which display "GoodBye" message on the homepage
        /// </summary>
        public async Task<IActionResult> Logout()
        {
            log.LogInformation("SignOut");
            await HttpContext.Authentication.SignOutAsync(Global.BASIC_AUTH_COOKIE);
            return RedirectToAction("Index", "Home", new {bye=true});
        }

        public IActionResult RegisterUser(RegisterUserViewModel user)
        {
            return RedirectToAction("IndexLogged", "Home");
        }

        public string Fobidden()
        {
            return "Fobidden";
        }
    }
}
