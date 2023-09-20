using CinemaTickets.Data.Cart;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTickets.Data.ViewComponents
{
    public class ShoppingCartView:ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartView(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }
        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            return View(items.Count);
        }
    }
}
