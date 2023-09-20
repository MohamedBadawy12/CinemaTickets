using CinemaTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
	public class OrderServices : IOrderServices
	{
		private readonly AppDbContext _context;

		public OrderServices(AppDbContext context)
		{
			_context = context;
		}
		public async Task<List<Order>> GetOrderByUserId(string userId, string userRole)
		{
			var Orders = await _context.Orders.Include(n => n.Items).ThenInclude(n => n.Movies).Include(n => n.User).ToListAsync();
			if (userRole != "Admin")
			{
				Orders=Orders.Where(n=>n.UserId == userId).ToList();
			}
			return Orders;
		}

		public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmail)
		{
			var order = new Order()
			{
				UserId = userId,
				Email = userEmail
			};
			await _context.Orders.AddAsync(order);
			await _context.SaveChangesAsync();
			foreach (var item in items)
			{
				var orderItem = new OrderItem()
				{
					Amount = item.Amount,
					MovieId=item.Movies.Id,
					OrderId=order.Id,
					Price=item.Movies.Price
				};
				await _context.OrderItems.AddAsync(orderItem);
			}
			await _context.SaveChangesAsync();
		}
		//public void RemoveOrder(int id)
		//{
		//	 var order =  _context.Orders.FirstOrDefault(x => x.Id == id);
		//	 _context.Orders.Remove(order);
		//	 _context.SaveChangesAsync();
		//}
	}
}
