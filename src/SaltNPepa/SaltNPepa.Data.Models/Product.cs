using SaltNPepa.Data.Models.Enum;
using System.Collections.Generic;

namespace SaltNPepa.Data.Models
{
    public class Product:BaseModel<string>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public ProductType ProductType { get; set; }

        public string Details { get; set; }

        public int Quantity { get; set; }

        public ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
