using CinemaTickets.Data.Services;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CinemaTickets.Controllers
{
	[Authorize]
	public class OrderController : Controller
	{
		private readonly IMovieService _movieService;
		private readonly IOrderServices _orderServices;

		public OrderController(IMovieService movieService,IOrderServices orderServices) 
		{
			_movieService = movieService;
			_orderServices = orderServices;
		}
		public async Task<IActionResult> Index()
		{
			string userId= User.FindFirstValue(ClaimTypes.NameIdentifier);
			string userRole = User.FindFirstValue(ClaimTypes.Role);
			var orders = await _orderServices.GetOrderByUserId(userId,userRole);
			return View(orders);
		}
	}
}
