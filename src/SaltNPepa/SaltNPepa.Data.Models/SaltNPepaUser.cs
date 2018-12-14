using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SaltNPepa.Data.Models
{
    // Add profile data for application users by adding properties to the SaltNPepaUser class
    public class SaltNPepaUser : IdentityUser
    {
        public string DefaultAddress { get; set; }

        public string Addresses { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
