using CinemaTickets.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
	public interface IOrderServices
	{
		Task SortOrderAsync(List<ShoppingCartItem> items, string userId, string userEmail);
		Task<List<Order>> GetOrderByUserId(string userId,string userRole);
	}
}
