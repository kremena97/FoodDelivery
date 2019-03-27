using FoodDelivery.Data.Models.Contracts;

namespace FoodDelivery.Data.Models
{
    public class CartProduct:BaseModel<string>
    {
        public string CartId { get; set; }
        public Cart Cart { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
