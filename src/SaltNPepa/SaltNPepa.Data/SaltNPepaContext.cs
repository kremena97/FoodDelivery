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

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Delivery> Deliveries { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cart>()
                .HasOne(x => x.Delivery)
                .WithOne(x => x.Receipt)
                .HasForeignKey<Delivery>(x => x.ReceiptId);

            base.OnModelCreating(builder);
        }
    }
}
