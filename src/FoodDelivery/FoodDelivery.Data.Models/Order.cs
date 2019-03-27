using FoodDelivery.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using FoodDelivery.Data.Models.Contracts;
namespace FoodDelivery.Data.Models
{
    public class Order : BaseModel<string>
    {
        public decimal TotalPrice { get; set; }

        public Delivery Delivery { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public string ContactPhone { get; set; }

        public int? DeliveryAddressId { get; set; }
        public virtual Address DeliveryAddress { get; set; }

        public string FoodDeliveryUserId { get; set; }
        public FoodDeliveryUser FoodDeliveryUser { get; set; }

        public DateTime? OrderTime { get; set; }

        public DateTime? DeliveredTime { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
