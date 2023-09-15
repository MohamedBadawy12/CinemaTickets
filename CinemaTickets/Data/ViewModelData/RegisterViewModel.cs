using System.ComponentModel.DataAnnotations;

namespace CinemaTickets.Data.ViewModelData
{
	public class RegisterViewModel
	{
		[Display(Name ="Full Name")]
		[Required(ErrorMessage ="Full Name Is Required")]
		public string FullName { get; set; }
		[Display(Name = "Email")]
		[Required(ErrorMessage = "Email Is Required")]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Display(Name = "Confirm Password")]
		[Required(ErrorMessage ="Confirm Password Is Required")]
		[DataType(DataType.Password)]
		[Compare("Password",ErrorMessage ="Passwords Not Match")]
		public string ConfirmPassword { get; set; }
	}
}
