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

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductOrder>()
                .HasKey(po => new { po.ProductId, po.OrderId });
            builder.Entity<ProductOrder>()
                .HasOne(p => p.Product)
                .WithMany(po => po.ProductOrders)
                .HasForeignKey(p => p.ProductId);
            builder.Entity<ProductOrder>()
                .HasOne(o => o.Order)
                .WithMany(or => or.OrderProducts)
                .HasForeignKey(o => o.OrderId);
            base.OnModelCreating(builder);
        }
    }
}
