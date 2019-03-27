using FoodDelivery.Data.Models.Contracts;
using System;

namespace FoodDelivery.Data.Models
{
    public class Delivery : BaseModel<string>
    {
        public string CartId { get; set; }
        public Cart Cart { get; set; }
        
        public DateTime? EstimatedDeliveryTime { get; set; }
        
        public Status DeliveryStatus { get; set; }
    }
}
