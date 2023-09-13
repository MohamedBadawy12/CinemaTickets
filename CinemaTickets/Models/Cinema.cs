using CinemaTickets.Data.BaseRepository;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaTickets.Models
{
    public partial class Cinema: IEntityBase
	{
        public int Id { get; set; }
        public string Logo { get; set; }
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 chars")]
		public string Name { get; set; }
        public string Description { get; set; }

        public List<Movies> Movies { get; set; }
    }
}
