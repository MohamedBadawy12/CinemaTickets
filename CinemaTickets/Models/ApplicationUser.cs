using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CinemaTickets.Models
{
	public class ApplicationUser:IdentityUser
	{
		[Display(Name ="Full Name")]
		public string FullName { get; set; }
	}
}
