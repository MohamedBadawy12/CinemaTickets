using CinemaTickets.Data.BaseRepository;
using CinemaTickets.Models;

namespace CinemaTickets.Data.Services
{
	public class ProducerService:EntityBaseRepository<Producer>,IProducerServices
	{
		public ProducerService(AppDbContext context) : base(context)
		{

		}
	}
}
