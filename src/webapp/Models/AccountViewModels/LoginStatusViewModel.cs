using System.ComponentModel.DataAnnotations;

namespace Webapplication.Models.AccountViewModels
{
    public class LoginStatusViewModel : LoginViewModel
    {
        public bool IsSignin { get; set; }
    }
}