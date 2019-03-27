using System.Collections.Generic;

namespace FoodDelivery.Web.Areas.Cart.Models
{
    public class CartViewModel
    {
        public IList<CartItemsViewModel> CartItems { get; set; }

        public string Total { get; set; }
    }
}
