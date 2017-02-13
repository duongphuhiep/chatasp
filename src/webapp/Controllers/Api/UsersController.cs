using System.Threading.Tasks;
using Dal;
using Dal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Filters;
using Webapplication.Helpers;
using Webapplication.Models;
using WebApplication.Helpers;

namespace WebApplication.Controllers.Api
{
    [ApiVersion("1.0")]
    public class UsersController : Controller
    {
        private readonly ILogger _log;
        private readonly IUserStore _userStore;

        public UsersController(ILogger<UsersController> logger, IUserStore userStore)
        {
            _log = logger;
            _userStore = userStore;
        }

        [ServiceFilter(typeof(ValidateModelAttribute))]
        [HttpPost]
        public async Task<JsonResult> Register([FromBody] RegisterUserRequest req)
        {
            var newUser = new User();
            newUser.Email = req.Email;
            newUser.NickName = req.NickName;
            newUser.HashedPassword = StringUtils.HashSalted(req.Password);
            newUser.FirstName = req.FirstName;
            newUser.LastName = req.LastName;

            await _userStore.AddUser(newUser);
            await Authenticator.Login(HttpContext, _userStore, newUser.Email, newUser.HashedPassword);

            var resu = new RegisterUserResponse();
            resu.NickName = req.NickName;
            resu.Email = req.Email;
            return Json(resu);
        }
    }
}
