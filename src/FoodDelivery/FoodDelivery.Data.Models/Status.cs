using FoodDelivery.Data.Models.Contracts;
using FoodDelivery.Data.Models.Enum;

namespace FoodDelivery.Data.Models
{
    public class Status : BaseModel<string>
    {
        public DeliveryStatus StatusName { get; set; }
    }
}
