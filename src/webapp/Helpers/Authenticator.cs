using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Dal;
using Microsoft.AspNetCore.Http;

namespace WebApplication.Helpers
{
    public class Authenticator
    {
        /// <summary>
        /// Login to the current user session
        /// </summary>
        /// <param name="email"></param>
        /// <param name="hashedPassword"></param>
        public static async Task Login(HttpContext ctx, IUserStore _userStore, string email, string hashedPassword)
        {
            var authUser = await _userStore.Authenticate(email, hashedPassword);
            if (authUser == null)
            {
                return;
            }
            var principal = createClaims(authUser.Email, authUser.NickName);
            await ctx.Authentication.SignInAsync(Global.AUTH_USER_COOKIE, principal);
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
