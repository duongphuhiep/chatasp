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

        public IActionResult RegisterUser(RegisterUserViewModel user)
        {
            log.LogInformation("Registered", user);
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
