using CinemaTickets.Data.Enums;
using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CinemaTickets.Data.ViewModelData
{
	public class NewMovieViewModel
	{
		public int Id { get; set; }
		[Display(Name = "Name")]
		[Required(ErrorMessage = "Movie Name Is Required")]
		public string Name { get; set; }
		[Display(Name = "Description")]
		[Required(ErrorMessage = "Movie Description Is Required")]
		public string Description { get; set; }
		[Display(Name = "Price")]
		[Required(ErrorMessage = "Movie Price Is Required")]
		public decimal Price { get; set; }
		[Display(Name = "Image Url")]
		[Required(ErrorMessage = "Movie Image Url Is Required")]
		public string ImageUrl { get; set; }
		public TimeDate TimeDate { get; set; }
		[Display(Name = "Select Category")]
		[Required(ErrorMessage = "Movie Category is required")]
		public MoviesCategory MoviesCategory { get; set; }
		[Display(Name = "Select actor(s)")]
		[Required(ErrorMessage = "Movie actor(s) is required")]
		public List<int> ActorId { get; set; }

		[Display(Name = "Select a cinema")]
		[Required(ErrorMessage = "Movie cinema is required")]
		public int CinemaId { get; set; }

		[Display(Name = "Select a producer")]
		[Required(ErrorMessage = "Movie producer is required")]
		public int ProducerId { get; set; }
	}
	public class TimeDate
	{
		[Display(Name = "Movie start date")]
		[Required(ErrorMessage = "Start Date Is Required")]
		public DateTime StartTime { get; set; }
		[Display(Name = "Movie End date")]
		[Required(ErrorMessage = "End Date Is Required")]
		public DateTime EndTime { get; set; }
	}
}
