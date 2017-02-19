using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Webapplication.Models
{
    public class LoginRequest
    {
		[Required]
		[EmailAddress]
		public string Login { get; set; }

		[Required]
        public string Password { get; set; }
    }
}
