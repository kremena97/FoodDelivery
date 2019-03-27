using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FoodDelivery.Data.Models
{
    // Add profile data for application users by adding properties to the SaltNPepaUser class
    public class FoodDeliveryUser : IdentityUser
    {
        public FoodDeliveryUser()
        {
            this.Addresses = new HashSet<Address>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public ICollection<Order> Orders { get; set; }

        public string CartId { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
