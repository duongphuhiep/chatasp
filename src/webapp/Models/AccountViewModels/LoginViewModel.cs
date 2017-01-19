using System.ComponentModel.DataAnnotations;

namespace Webapplication.Models.AccountViewModels
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string NickName { get; set; }
    }
}