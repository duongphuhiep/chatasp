using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using Dal;
using Dal.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Filters;
using Webapplication.Models;

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
        public IActionResult Register([FromBody] RegisterUserRequest req)
        {
			var newUser = new User();
			newUser.Email = req.Email;
			newUser.NickName = req.NickName;
			newUser.HashedPassword = HashSalted(req.Password);
			newUser.FirstName = req.FirstName;
			newUser.LastName = req.LastName;

			_userStore.AddUser(newUser);
			login(newUser.Email, newUser.HashedPassword);

			var resu = new RegisterUserResponse();
			resu.NickName = req.NickName;
			resu.Email = req.Email;
            return Json(resu);
        }

		/// <summary>
		/// Login to the current user session
		/// </summary>
		/// <param name="email"></param>
		/// <param name="hashedPassword"></param>
		private async void login(string email, string hashedPassword)
        {
            _log.LogInformation("SignIn", email);
            var authUser = await _userStore.Authenticate(email, hashedPassword);
            if (authUser == null)
            {
                return;
            }
            var principal = createClaims(authUser.Email, authUser.NickName);
            await HttpContext.Authentication.SignInAsync(Global.AUTH_USER_COOKIE, principal);
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

		private static string HashSalted(string password)
		{
			byte[] salt = new byte[128 / 8];
			using (var rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(salt);
			}
			// derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
			string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
				password: password,
				salt: salt,
				prf: KeyDerivationPrf.HMACSHA1,
				iterationCount: 10000,
				numBytesRequested: 256 / 8));
			return hashed;
		}
    }
}
