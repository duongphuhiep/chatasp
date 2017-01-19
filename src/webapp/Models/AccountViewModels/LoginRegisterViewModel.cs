using System.ComponentModel.DataAnnotations;

namespace Webapplication.Models.AccountViewModels
{
    public class LoginRegisterViewModel: LoginViewModel
    {
        [Required]
        public string NickName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}