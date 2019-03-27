using FoodDelivery.Data.Models.Contracts;

namespace FoodDelivery.Data.Models
{
    public class Address : BaseModel<string>
    {
        public string Country { get; set; }

        public string CityId { get; set; }
        public virtual City City { get; set; }

        public string FoodDeliveryUserId { get; set; }
        public virtual FoodDeliveryUser FoodDeliveryUser { get; set; }

        public string AddressText { get; set; }
    }
}
