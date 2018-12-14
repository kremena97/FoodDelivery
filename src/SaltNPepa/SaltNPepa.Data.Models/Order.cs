using SaltNPepa.Data.Models.Enum;
using System;
using System.Collections.Generic;

namespace SaltNPepa.Data.Models
{
    public class Order:BaseModel<string>
    {
        public SaltNPepaUser Customer { get; set; }
        public int CutomerId { get; set; }

        public ICollection<ProductOrder> OrderProducts { get; set; }

        public DateTime OrderTime { get; set; }

        public DateTime DeliveredTime { get; set; }

        public TimeSpan EstimatedDeliveryTime { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public string Note { get; set; }

        public string ProviderName { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
