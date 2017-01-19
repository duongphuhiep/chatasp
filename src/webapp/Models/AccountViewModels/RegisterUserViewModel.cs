using System.ComponentModel.DataAnnotations;

namespace Webapplication.Models.AccountViewModels
{
    public class RegisterUserViewModel: LoginViewModel
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}