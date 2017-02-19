using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Dal;
using Dal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

		/// <summary>
		/// This factory is auto generated by AutoFac: http://docs.autofac.org/en/latest/resolve/relationships.html#parameterized-instantiation-func-x-y-b
		/// </summary>		
		private readonly Func<HttpContext, IUserStore, ILogger, IAuthenticator> _authFactory;

		public UsersController(ILogger<UsersController> logger, IUserStore userStore, Func<HttpContext, IUserStore, ILogger, IAuthenticator> authFactory)
		{
			_log = logger;
			_userStore = userStore;
			_authFactory = authFactory;
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
			var _authenticator = _authFactory(this.HttpContext, _userStore, _log);
			var u = await _authenticator.Login(newUser.Email, newUser.HashedPassword);

			var resu = new RegisterUserResponse() { User = u };
			return Json(resu);
		}
	}
}
