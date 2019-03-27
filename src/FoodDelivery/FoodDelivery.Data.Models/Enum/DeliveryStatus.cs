using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.Data.Models.Enum
{
    public enum DeliveryStatus
    {
        [Display(Name = "Awaiting Аpproval")]
        AwaitingАpproval = 1,

        [Display(Name = "Approved")]
        Approved = 2,

        [Display(Name = "Cooking Process")]
        CookingProcess = 3,

        [Display(Name = "Quality Check")]
        QualityCheck = 4,

        [Display(Name = "Delivery")]
        Delivery = 5,

        [Display(Name = "Delivered")]
        Delivered = 6
    }
}
