using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Webapplication.Models.AccountViewModels;

namespace WebApplication.ViewComponents
{
    public class Login : ViewComponent
    {
        private readonly ILogger<Login> log;
        public Login(ILogger<Login> logger)
        {
            log = logger;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var resu = await getLoginStatus();
            return View(resu);
        }

        private Task<LoginStatusViewModel> getLoginStatus() {
            return Task.FromResult(new LoginStatusViewModel());
        }
    }
}