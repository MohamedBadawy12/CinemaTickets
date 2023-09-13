using CinemaTickets.Data.BaseRepository;
using CinemaTickets.Models;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaTickets.Data.ViewModelData;

namespace CinemaTickets.Data.Services
{
	public interface IMovieService:IEntityBaseRepository<Movies>
	{
		Task<Movies> GetMovieByIdAsync(int id);
		Task<NewMovieDropDownViewModelcs> GetNewMovieDropDownsValues();
		Task AddNewMovieAsync(NewMovieViewModel data);
		Task UpddteMovieAsync(NewMovieViewModel data);
	}
}
