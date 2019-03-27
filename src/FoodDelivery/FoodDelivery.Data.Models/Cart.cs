using FoodDelivery.Data.Models.Contracts;
using System;
using System.Collections.Generic;

namespace FoodDelivery.Data.Models
{
    public class Cart : BaseModel<string>
    {
        public FoodDeliveryUser User { get; set; }

        public ICollection<CartProduct> CartProducts { get; set; }
    }
}
