using System.ComponentModel.DataAnnotations;

public class NickNameAttribute : ValidationAttribute
{
	protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
		var v = value as string;
		if (string.IsNullOrEmpty(v))
			return new ValidationResult("empty string");
		if (v.Length<3)
			return new ValidationResult("too short");

		return ValidationResult.Success;
	}
}
