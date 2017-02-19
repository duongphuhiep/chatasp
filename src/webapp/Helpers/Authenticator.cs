using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Dal;
using Dal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace WebApplication.Helpers
{
	public interface IAuthenticator
	{
		Task<User> Login(string email, string hashedPassword);
		Task Logout();
	}

    public class Authenticator: IAuthenticator
    {
		private readonly HttpContext _ctx;
		private readonly IUserStore _userStore;
		
		private readonly ILogger _log;

		public Authenticator(HttpContext ctx, IUserStore userStore, ILogger log)
		{
			this._ctx = ctx;
			this._userStore = userStore;
			this._log = log;
		}

        /// <summary>
        /// Login to the current user session
        /// </summary>
        /// <param name="email"></param>
        /// <param name="hashedPassword"></param>
        public async Task<User> Login(string email, string hashedPassword)
        {
			_log.LogInformation($"{nameof(Login)}({email})");
            var authUser = await _userStore.Authenticate(email, hashedPassword);
            if (authUser == null) return null;
            var principal = createClaims(authUser.Email, authUser.NickName);
            await _ctx.Authentication.SignInAsync(Global.AUTH_USER_COOKIE, principal);
			return authUser;
        }

		public Task Logout()
        {
			_log.LogInformation(nameof(Logout));
            return _ctx.Authentication.SignOutAsync(Global.AUTH_USER_COOKIE);
        }

        private static ClaimsPrincipal createClaims(string email, string nickName)
        {
            var id = new ClaimsIdentity();
            id.AddClaims(new List<Claim>
            {
                new Claim(nameof(User.Email), email),
                new Claim(nameof(User.NickName), nickName)
            });
            return new ClaimsPrincipal(id);
        }
    }
}
