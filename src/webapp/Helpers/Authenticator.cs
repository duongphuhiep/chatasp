using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Dal;
using Microsoft.AspNetCore.Http;

namespace WebApplication.Helpers
{
	public interface IAuthenticator
	{
		Task Login(string email, string hashedPassword);
		Task Logout();
	}

    public class Authenticator: IAuthenticator
    {
		private readonly HttpContext _ctx;
		private readonly IUserStore _userStore;

		public Authenticator(HttpContext ctx, IUserStore userStore)
		{
			this._ctx = ctx;
			this._userStore = userStore;
		}

        /// <summary>
        /// Login to the current user session
        /// </summary>
        /// <param name="email"></param>
        /// <param name="hashedPassword"></param>
        public async Task Login(string email, string hashedPassword)
        {
            var authUser = await _userStore.Authenticate(email, hashedPassword);
            if (authUser == null) return;
            var principal = createClaims(authUser.Email, authUser.NickName);
            await _ctx.Authentication.SignInAsync(Global.AUTH_USER_COOKIE, principal);
        }

		public Task Logout()
        {
            return _ctx.Authentication.SignOutAsync(Global.AUTH_USER_COOKIE);
        }

        private static ClaimsPrincipal createClaims(string email, string nickName)
        {
            var id = new ClaimsIdentity();
            id.AddClaims(new List<Claim>
            {
                new Claim(nameof(Dal.Models.User.Email), email),
                new Claim(nameof(Dal.Models.User.NickName), nickName)
            });
            return new ClaimsPrincipal(id);
        }
    }
}
