using System.Collections.Generic;
using FoodDelivery.Data.Models.Contracts;

namespace FoodDelivery.Data.Models
{
    public class Product : BaseModel<string>
    {
        public Product()
        {
            this.CartProducts = new HashSet<CartProduct>();
        }

        public string Name { get; set; }

        public decimal Price { get; set; }
        
        public virtual Category Category { get; set; }

        public string Details { get; set; }

        public string Picture { get; set; }

        public ICollection<CartProduct> CartProducts { get; set; }
    }
}
