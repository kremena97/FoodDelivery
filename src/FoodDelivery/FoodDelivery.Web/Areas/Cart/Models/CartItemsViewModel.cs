namespace FoodDelivery.Web.Areas.Cart.Models
{
    public class CartItemsViewModel
    {
        public string Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }

        public int Quantity { get; set; }

        public string Total { get; set; }

        public decimal TotalDecimal { get; set; }
    }
}
