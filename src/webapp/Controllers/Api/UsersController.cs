using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Dal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Webapplication.Models.AccountViewModels;

namespace WebApplication.Controllers.Api
{
    [ApiVersion("1.0")]
    public class UsersController : Controller
    {
        private readonly ILogger _log;
        private readonly IUserStore _userStore;

        public UsersController(ILogger<AccountController> logger, IUserStore userStore)
        {
            _log = logger;
            _userStore = userStore;
        }

        [HttpPost]
        public IActionResult Add(RegisterUserViewModel user)
        {
            return Json(user);
        }
    }
}
