using CinemaTickets.Data.BaseRepository;
using CinemaTickets.Models;

namespace CinemaTickets.Data.Services
{
	public class CinemaServices : EntityBaseRepository<Cinema>,ICinemaService
	{
		public CinemaServices(AppDbContext context) : base(context)
		{

		}
	}
}
