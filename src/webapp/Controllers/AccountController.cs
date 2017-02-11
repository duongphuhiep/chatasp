using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Dal;
using Dal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Webapplication.Models.AccountViewModels;

namespace WebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger log;
        private readonly IUserStore _userStore;

        public AccountController(ILogger<AccountController> logger, IUserStore userStore)
        {
            log = logger;
            _userStore = userStore;
        }

        public async Task<IActionResult> Login(LoginStatusViewModel login)
        {
            log.LogInformation("SignIn", login);
            var authUser = await _userStore.Authenticate(login.Email, login.Password);
            if (authUser==null)
            {
                return View("Login");
            }

            var principal = createClaims(authUser.Email, authUser.NickName);
            await HttpContext.Authentication.SignInAsync(Global.AUTH_USER_COOKIE, principal);

            return RedirectToAction("Index", "Home");
        }

		private ClaimsPrincipal createClaims(string email, string nickName)
		{
			var id = new ClaimsIdentity();
            id.AddClaims(new List<Claim>
            {
                new Claim(nameof(Dal.Models.User.Email), email),
                new Claim(nameof(Dal.Models.User.NickName), nickName)
            });
            return new ClaimsPrincipal(id);
		}


        /// <summary>
        /// Redirect user to Home page which display "GoodBye" message on the homepage
        /// </summary>
        public async Task<IActionResult> Logout()
        {
            log.LogInformation("SignOut");
            await HttpContext.Authentication.SignOutAsync(Global.AUTH_USER_COOKIE);
            return RedirectToAction("Index", "Home", new {bye=true});
        }

        public IActionResult RegisterUser(RegisterUserViewModel user)
        {
            return RedirectToAction("Index", "Home");
        }

        public string Fobidden()
        {
            return "Fobidden";
        }
    }
}
