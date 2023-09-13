using CinemaTickets.Models;
using System.Collections.Generic;

namespace CinemaTickets.Data.ViewModelData
{
	public class NewMovieDropDownViewModelcs
	{
        public NewMovieDropDownViewModelcs()
        {
            Producers=new List<Producer>();
            Cinemas=new List<Cinema>();
            Actors=new List<Actor>();
        }
        public List<Producer> Producers { get; set; }
		public List<Cinema> Cinemas { get; set; }
		public List<Actor> Actors { get; set; }
	}
}
