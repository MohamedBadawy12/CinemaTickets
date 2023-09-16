using System.ComponentModel.DataAnnotations;

namespace CinemaTickets.Data.ViewModelData
{
	public class RoleViewModel
	{
		[Required]
		public string RoleName { get; set; }
	}
}
