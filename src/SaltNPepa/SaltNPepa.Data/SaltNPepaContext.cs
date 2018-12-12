using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SaltNPepa.Data.Models;

namespace SaltNPepa.Data
{
    public class SaltNPepaContext : IdentityDbContext<SaltNPepaUser>
    {
        public SaltNPepaContext(DbContextOptions<SaltNPepaContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
