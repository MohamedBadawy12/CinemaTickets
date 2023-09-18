using CinemaTickets.Data.BaseRepository;
using CinemaTickets.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CinemaTickets.Models
{
    public class Movies: IEntityBase
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Triler { get; set; }
        public TimeDate TimeDate { get; set; }
        public MoviesCategory MoviesCategory { get; set; }
        //public List<int> ActorId { get; set; }
        public List<Actor_Movie> Actor_Movie { get; set; }

        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
    }
    public class TimeDate
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
