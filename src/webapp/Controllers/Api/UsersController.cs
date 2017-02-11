using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Dal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Filters;
using Webapplication.Models;
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

		[ServiceFilter(typeof(ValidateModelAttribute))]
        [HttpPost]
        public IActionResult Register([FromBody] RegisterUserRequest newUser)
        {
			var resu = new RegisterUserResponse();
			resu.NickName = newUser.NickName;
			resu.Email = newUser.Email;
            return Json(resu);
        }
    }
}
