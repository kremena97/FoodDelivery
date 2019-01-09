using System.Collections.Generic;
using SaltNPepa.Data.Models.Contracts;

namespace SaltNPepa.Data.Models
{
    public class Product : BaseModel<string>
    {
        public Product()
        {
            this.CartProducts = new HashSet<CartProduct>();
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public Category Category { get; set; }

        public string Details { get; set; }

        public string Picture { get; set; }

        public ICollection<CartProduct> CartProducts { get; set; }
    }
}
