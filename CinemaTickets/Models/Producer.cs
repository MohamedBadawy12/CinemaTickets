using CinemaTickets.Data.BaseRepository;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CinemaTickets.Models
{
    public class Producer: IEntityBase
	{
        public int Id { get; set; }
		[Display(Name = "Profile Picture")]
		[Required(ErrorMessage = "Profile Picture Is Required")]
		public string ProfilePictureUrl { get; set; }

		[Display(Name = "Full Name")]
		[Required(ErrorMessage = "Full Name Is Required")]
		[StringLength(90, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 90 chars")]
		public string FullName { get; set; }

		[Display(Name = "Biography")]
		[Required(ErrorMessage = "Biography Is Required")]
		public string Bio { get; set; }
		public List<Movies> Movies { get; set; }
    }
}
