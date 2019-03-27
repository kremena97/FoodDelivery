using FoodDelivery.Data.Models.Contracts;

namespace FoodDelivery.Data.Models
{
    public class CategoryProducts:BaseModel<string>
    {
        public string ProductId { get; set; }
        public Product Product { get; set; }

        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
