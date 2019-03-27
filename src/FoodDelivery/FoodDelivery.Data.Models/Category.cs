using System.Collections.Generic;
using FoodDelivery.Data.Models.Contracts;
using FoodDelivery.Data.Models.Enum;

namespace FoodDelivery.Data.Models
{
    public class Category : BaseModel<string>
    {
        public ProductType Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
