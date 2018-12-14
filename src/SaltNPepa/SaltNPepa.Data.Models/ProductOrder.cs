using System;
using System.Collections.Generic;
using System.Text;

namespace SaltNPepa.Data.Models
{
    public class ProductOrder
    {
        public string ProductId { get; set; }
        public Product Product { get; set; }

        public string OrderId { get; set; }
        public Order Order { get; set; }
    }
}
