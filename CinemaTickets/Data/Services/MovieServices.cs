using CinemaTickets.Data.BaseRepository;
using CinemaTickets.Data.Enums;
using CinemaTickets.Data.ViewModelData;
using CinemaTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CinemaTickets.Data.Services
{
	public class MovieServices : EntityBaseRepository<Movies>,IMovieService
	{
		private readonly AppDbContext _context;
		public MovieServices(AppDbContext context) : base(context)
		{
			_context=context;
		}

		public async Task AddNewMovieAsync(NewMovieViewModel data)
		{
			var newMovie = new Movies()
			{
				Name = data.Name,
				Description = data.Description,
				Price = data.Price,
				ImageUrl = data.ImageUrl,
				Triler =data.Triler,
				CinemaId = data.CinemaId,
				TimeDate = new Models.TimeDate { StartTime = data.TimeDate.StartTime,
					EndTime = data.TimeDate.EndTime },
				MoviesCategory = data.MoviesCategory,
				ProducerId = data.ProducerId,
			};
			await _context.Movies.AddAsync(newMovie);
			await _context.SaveChangesAsync();
			foreach(var actorId in data.ActorId)
			{
				var newActorMovie = new Actor_Movie()
				{
					MovieId = newMovie.Id,
					ActorId = actorId
				};
				await _context.Actor_Movies.AddAsync(newActorMovie);
			}
			await _context.SaveChangesAsync();
		}

        public async Task<Movies> GetMovieByIdAsync(int id)
		{
			var movieDetails = await _context.Movies
				.Include(c => c.Cinema)
				.Include(p => p.Producer)
				.Include(am => am.Actor_Movie)
				.ThenInclude(a => a.Actor)
				.FirstOrDefaultAsync(n=>n.Id==id);
			return movieDetails;
		}

		public async Task<NewMovieDropDownViewModelcs> GetNewMovieDropDownsValues()
		{
			var data = new NewMovieDropDownViewModelcs()
			{
				Actors = await _context.Actors.OrderBy(a=>a.FullName).ToListAsync(),
				Cinemas = await _context.Cinemas.OrderBy(c => c.Name).ToListAsync(),
				Producers=await _context.producers.OrderBy(p=>p.FullName).ToListAsync(),
			};
			return data;
		}
        public async Task UpddteMovieAsync(NewMovieViewModel data)
        {
            var movieUpdtae =await _context.Movies.FirstOrDefaultAsync(x=>x.Id==data.Id);
			if(movieUpdtae != null)
			{
				movieUpdtae.Name = data.Name;
				movieUpdtae.Description = data.Description;
				movieUpdtae.Price = data.Price;
				movieUpdtae.ImageUrl = data.ImageUrl;
				movieUpdtae.Triler = data.Triler;
				movieUpdtae.CinemaId = data.CinemaId;
				movieUpdtae.TimeDate = new Models.TimeDate
				{
					StartTime = data.TimeDate.StartTime,
					EndTime = data.TimeDate.EndTime
				};
				movieUpdtae.MoviesCategory = data.MoviesCategory;
				movieUpdtae.ProducerId = data.ProducerId;
				await _context.SaveChangesAsync();
			}
			//Remove Existing Actors
			var existingActor = _context.Actor_Movies.Where(n => n.MovieId == data.Id).ToList();
			_context.Actor_Movies.RemoveRange(existingActor);
			await _context.SaveChangesAsync();

			//Add Actor_Movie
			foreach(var actorId in data.ActorId)
			{
				var newActorMovie = new Actor_Movie()
				{
					MovieId = data.Id,
					ActorId = actorId,
				};
				await _context.Actor_Movies.AddAsync(newActorMovie);
			}
			await _context.SaveChangesAsync();
        }
    }
}
