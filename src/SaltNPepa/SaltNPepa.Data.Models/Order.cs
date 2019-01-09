using SaltNPepa.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using SaltNPepa.Data.Models.Contracts;
namespace SaltNPepa.Data.Models
{
    public class Order : BaseModel<string>
    {
        public decimal TotalPrice { get; set; }

        public Delivery Delivery { get; set; }

        public int? DeliveryAddressId { get; set; }
        public virtual Address DeliveryAddress { get; set; }

        public string SaltNPepaUserId { get; set; }
        public SaltNPepaUser SaltNPepaUser { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
