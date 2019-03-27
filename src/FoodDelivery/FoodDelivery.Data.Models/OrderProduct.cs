using FoodDelivery.Data.Models.Contracts;

namespace FoodDelivery.Data.Models
{
    public class OrderProduct : BaseModel<string>
    {
        public string OrderId { get; set; }
        public virtual Order Order { get; set; }

        public string ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
