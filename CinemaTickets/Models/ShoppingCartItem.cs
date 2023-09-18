namespace CinemaTickets.Models
{
	public class ShoppingCartItem
	{
		public int Id { get; set; }
		public Movies Movies { get; set; }
		public int Amount { get; set; }
		public string ShoppingCartId { get; set; }
	}
}
