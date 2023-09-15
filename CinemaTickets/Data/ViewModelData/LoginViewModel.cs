using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CinemaTickets.Data.ViewModelData
{
	public class LoginViewModel
	{
		[Display(Name = "Email")]
		[Required(ErrorMessage = "Email Is Required")]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
