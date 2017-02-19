using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Webapplication.Models
{
    public class RegisterUserRequest: IValidatableObject
    {
		[NickNameAttribute]
		public string NickName { get; set; }

		[Required/*(ErrorMessage = "The NickName field is required.")*/]
		[EmailAddress/*(ErrorMessage = "The Email field is not a valid e-mail address.")*/]
		//[Display(Name = "Dia chi thu dien tu")]
		public string Email { get; set; }

		[Required]
        public string Password { get; set; }

		[Required]
        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

		/// <summary>
		/// Perform Class-level validation.
		/// It is invoked only if all the Attribute-level validation pass
		/// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Password!=ConfirmPassword) {
				yield return new ValidationResult("Password and Password confirmation mismatched", new[] {nameof(Password), nameof(ConfirmPassword)});
			}
        }
    }
}
