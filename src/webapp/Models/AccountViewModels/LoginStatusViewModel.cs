using System.ComponentModel.DataAnnotations;

namespace Webapplication.Models.AccountViewModels
{
    public class LoginStatusViewModel : LoginViewModel
    {
        public string Password { get; set; }
        public bool IsSignedIn { get; set; }
    }
}