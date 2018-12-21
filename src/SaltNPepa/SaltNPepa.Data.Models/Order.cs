using SaltNPepa.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using SaltNPepa.Data.Models.Contracts;
namespace SaltNPepa.Data.Models
{
    public class Order : BaseModel<string>
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
