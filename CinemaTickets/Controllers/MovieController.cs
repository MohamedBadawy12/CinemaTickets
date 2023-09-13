using CinemaTickets.Data;
using CinemaTickets.Data.Services;
using CinemaTickets.Data.ViewModelData;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace CinemaTickets.Controllers
{
    public class MovieController : Controller
    {
		private readonly IMovieService _Service;
		public MovieController(IMovieService Service)
		{
			_Service = Service;
		}
		public async Task<IActionResult> Index()
        {
			var AllMovie = await _Service.GetAllAsync(c=>c.Cinema);
			return View(AllMovie);
        }
		public async Task<IActionResult> Create()
		{
			var movieDropDownList=await _Service.GetNewMovieDropDownsValues();
			ViewBag.Cinema = new SelectList(movieDropDownList.Cinemas, "Id", "Name");
			ViewBag.Actor = new SelectList(movieDropDownList.Actors, "Id", "FullName");
			ViewBag.Producer = new SelectList(movieDropDownList.Producers, "Id", "FullName");
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(NewMovieViewModel movie)
		{
			if(!ModelState.IsValid)
			{
				var movieDropDownList = await _Service.GetNewMovieDropDownsValues();
				ViewBag.Cinema = new SelectList(movieDropDownList.Cinemas, "Id", "Name");
                ViewBag.Actor = new SelectList(movieDropDownList.Actors, "Id", "FullName");
                ViewBag.Producer = new SelectList(movieDropDownList.Producers, "Id", "FullName");
				return View(movie);	
			}
			await _Service.AddNewMovieAsync(movie);
			return RedirectToAction(nameof(Index));
		}
        public async Task<IActionResult> Details(int id)
		{
			var movieDetails = await _Service.GetMovieByIdAsync(id);
			return View(movieDetails);
		}
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _Service.GetMovieByIdAsync(id);
			if(movieDetails == null)
				return View("NotFound");

			var data = new NewMovieViewModel()
			{
				Id = movieDetails.Id,
				Name = movieDetails.Name,
				Description = movieDetails.Description,
				ImageUrl = movieDetails.ImageUrl,
				Price = movieDetails.Price,
				TimeDate=new Data.ViewModelData.TimeDate()
				{
					StartTime=movieDetails.TimeDate.StartTime,
					EndTime=movieDetails.TimeDate.EndTime
				},
				MoviesCategory = movieDetails.MoviesCategory,
				CinemaId = movieDetails.CinemaId,
				ProducerId = movieDetails.ProducerId,
				ActorId = movieDetails.Actor_Movie.Select(n => n.ActorId).ToList(),
            };
			var movieDropDownData=await _Service.GetNewMovieDropDownsValues();
			ViewBag.Cinema = new SelectList(movieDropDownData.Cinemas, "Id", "Name");
            ViewBag.Producer = new SelectList(movieDropDownData.Producers, "Id", "FullName");
            ViewBag.Actor = new SelectList(movieDropDownData.Actors, "Id", "FullName");
			return View(data);
        }
		[HttpPost]
        public async Task<IActionResult> Edit(int id,NewMovieViewModel movie)
        {
			if (id != movie.Id)
				return View("Not Found");
			if (!ModelState.IsValid)
			{
                var movieDropDownData = await _Service.GetNewMovieDropDownsValues();
                ViewBag.Cinema = new SelectList(movieDropDownData.Cinemas, "Id", "Name");
                ViewBag.Producer = new SelectList(movieDropDownData.Producers, "Id", "FullName");
                ViewBag.Actor = new SelectList(movieDropDownData.Actors, "Id", "FullName");
				return View(movie);
            }
			await _Service.UpddteMovieAsync(movie);
			return RedirectToAction(nameof(Index));
        }
		public async Task <IActionResult>Searching(string search)
		{
			var allMovies=await _Service.GetAllAsync(c=>c.Cinema);
			if (!string.IsNullOrEmpty(search))
			{
				var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(search.ToLower()) ||
				n.Description.ToLower().Contains(search.ToLower())).ToList();
				//var filterResultItem = allMovies.Where(n=>string.Equals(n.Name, search,StringComparison.CurrentCultureIgnoreCase)||
				//string.Equals(n.Description,search, StringComparison.CurrentCultureIgnoreCase)).ToList();
				return View(nameof(Index), filteredResult);
			}
			return View(nameof(Index), allMovies);
		}
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				await _Service.DeleteAsync(id);
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("Exception", ex.InnerException.Message);
				return View(nameof(Details));
			}
		}
	}
}
