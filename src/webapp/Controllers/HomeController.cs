using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dal;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserStore _userStore;
        public HomeController(IUserStore userStore)
        {
            _userStore = userStore;
        }

        public async Task<ViewResult> Index(bool bye)
        {
            //display homepage for logged user
            var principal = await HttpContext.Authentication.AuthenticateAsync(Global.AUTH_USER_COOKIE);
            var email = principal?.FindFirst(nameof(Dal.Model.User.Email))?.Value;
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
