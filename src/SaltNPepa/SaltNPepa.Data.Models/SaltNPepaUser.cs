using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SaltNPepa.Data.Models
{
    // Add profile data for application users by adding properties to the SaltNPepaUser class
    public class SaltNPepaUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }
        
        public string Address { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
