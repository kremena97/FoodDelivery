using FoodDelivery.Data.Models.Contracts;
using FoodDelivery.Data.Models.Enum;

namespace FoodDelivery.Data.Models
{
    public class City : BaseModel<string>
    {
        public CityName Name { get; set; }
    }
}
