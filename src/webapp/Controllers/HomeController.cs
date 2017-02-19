using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dal;
using Microsoft.Extensions.Logging;
using System;
using WebApplication.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Webapplication.Models;
using Webapplication.Helpers;
using WebApp.Filters;
using Newtonsoft.Json.Linq;

namespace WebApplication.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger _log;
		private readonly IUserStore _userStore;
		private readonly Func<HttpContext, IUserStore, ILogger, IAuthenticator> _authFactory;
		public HomeController(ILogger<HomeController> logger, IUserStore userStore, Func<HttpContext, IUserStore, ILogger, IAuthenticator> authFactory)
		{
			_log = logger;
			_userStore = userStore;
			_authFactory = authFactory;
		}

		public ViewResult Index(bool bye)
		{
			_log.LogInformation("Home page reach");
			var principal = this.User;
			var email = principal?.FindFirst(nameof(Dal.Models.User.Email))?.Value;
			if (email != null)
			{
				_log.LogInformation($"Email claimed: {email}");
				//display HomePage for logged User
				return View("IndexLogged");
			}

			//display homepage for anonymous
			return View();
		}

		public async Task<IActionResult> Logout()
		{
			var _authenticator = _authFactory(this.HttpContext, _userStore, _log);
			await _authenticator.Logout();
			return RedirectToAction("Index", "Home", new { bye = true });
		}

		[ServiceFilter(typeof(ValidateModelAttribute))]
		[HttpPost]
		public async Task<IActionResult> Login([FromBody] LoginRequest req)
		{
			var _authenticator = _authFactory(this.HttpContext, _userStore, _log);
			var hashedPassword = StringUtils.HashSalted(req.Password);
			var u = await _authenticator.Login(req.Login, hashedPassword);
			return Json(new LoginResponse() { User = u });
		}

		/// <summary>
		/// Get user info from email. 
		/// if email is null or empty, it will return user info of the current logged user
		/// </summary>
		[HttpGet]
		[Authorize(Policy = nameof(Global.LOGGED_USER))]
		public async Task<IActionResult> GetProfile()
		{
			var email = this.User?.FindFirst(nameof(Dal.Models.User.Email))?.Value;
			if (string.IsNullOrEmpty(email))
				throw new InvalidOperationException("Email is not claimed"); //it shouldn't happen
			var u = await _userStore.FindUser(email);
			return Json(u);
		}

		//[Authorize(Policy = nameof(Global.LOGGED_USER))]
		public string About()
		{
			return "About";
		}
		public string Contact()
		{
			return "Contact";
		}
		public string Fobidden()
		{
			return "Forbidden";
		}
	}
}
