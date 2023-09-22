using CinemaTickets.Data;
using CinemaTickets.Data.BaseRepository;
using CinemaTickets.Data.Cart;
using CinemaTickets.Data.Services;
using CinemaTickets.Data.ViewModelData;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CinemaTickets.Controllers
{
	[Authorize]
	public class OrderController : Controller
	{
		private readonly IMovieService _movieService;
		private readonly IOrderServices _orderServices;
        private readonly ShoppingCart _shoppingCart;
        private readonly AppDbContext _context;

		public OrderController(IMovieService movieService,IOrderServices orderServices,ShoppingCart shoppingCart,AppDbContext context) 
		{
			_movieService = movieService;
			_orderServices = orderServices;
            _shoppingCart = shoppingCart;
            _context = context;
		}
		public async Task<IActionResult> Index()
		{
			string userId= User.FindFirstValue(ClaimTypes.NameIdentifier);
			string userRole = User.FindFirstValue(ClaimTypes.Role);
			var orders = await _orderServices.GetOrderByUserId(userId,userRole);
			return View(orders);
		}
		//public IActionResult ClearAllData()
		//{
		//	foreach(var item in _context.Orders)
		//	{
		//		_context.Orders.Remove(item);
		//	}
		//	_context.SaveChanges();
		//	return RedirectToAction("Index");	
		//}
		
		public IActionResult ShoppingCart()
		{
			var items = _shoppingCart.GetShoppingCartItems();
			_shoppingCart.ShoppingCartItems = items;
			var response = new ShoppingCartViewModel()
			{
				shoppingCart = _shoppingCart,
				ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
			};
			return View(response);
		}
		public async Task<IActionResult> AddItemToShoppingCart(int id)
		{
			var item =await _movieService.GetMovieByIdAsync(id);
			if(item != null)
			{
				_shoppingCart.AddItemToCart(item);
			}
			return RedirectToAction(nameof(ShoppingCart));
		}
		public async Task<IActionResult> RemoveFromShoppingCart(int id)
		{
			var item = await _movieService.GetMovieByIdAsync(id);
			if( item != null )
			{
				_shoppingCart.RemoveItemFromCart(item);
			}
			return RedirectToAction(nameof(ShoppingCart));
		}
		public async Task<IActionResult> OrderCompleted()
		{
			var items = _shoppingCart.GetShoppingCartItems();
			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			string userEmail = User.FindFirstValue(ClaimTypes.Email);

			await _orderServices.StoreOrderAsync(items, userId, userEmail);
			await _shoppingCart.clearShoppingCartAsync();
			return View("OrderCompleted");
		}
		public IActionResult Payment()
		{
			return View();	
		}
		[HttpPost]
		public async Task<IActionResult> Payment(PaymentCard paymentCard)
		{
			if (ModelState.IsValid)
			{
				await _context.AddAsync(paymentCard);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(OrderCompleted));
			}
			return View(paymentCard);
		}
	}
}
