using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dal;
using Microsoft.Extensions.Logging;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
		private readonly ILogger _log;
        private readonly IUserStore _userStore;
        public HomeController(ILogger<HomeController> logger, IUserStore userStore)
        {
			_log = logger;
            _userStore = userStore;
        }

        public async Task<ViewResult> Index(bool bye)
        {
			_log.LogInformation("******************* GO HOME ********************");

            //display homepage for logged user
            var principal = await HttpContext.Authentication.AuthenticateAsync(Global.AUTH_USER_COOKIE);
            var email = principal?.FindFirst(nameof(Dal.Models.User.Email))?.Value;
            if (email!=null) {
                var user = await _userStore.FindUser(email);
                if (user != null)
                {
                    return View("IndexLogged", user);
                }
            }
            //display homepage for anonymous
            ViewData[Global.BYE] = bye;
            return View();
        }

//        [Authorize(Policy = nameof(Global.LOGGED_USER))]
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
