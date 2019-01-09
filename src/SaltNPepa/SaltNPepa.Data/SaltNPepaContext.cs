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

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartProduct> CartProducts { get; set; }

        public DbSet<Category> Categories { get; set; }
        
        public DbSet<City> Cities { get; set; }

        public DbSet<Delivery> Deliveries { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrderProduct>().HasKey(x => new { x.OrderId, x.ProductId });

            builder.Entity<CartProduct>().HasKey(x => new { x.ProductId, x.CartId });

            builder.Entity<Category>()
                .HasMany(x => x.Products)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.Id);



            base.OnModelCreating(builder);
        }
    }
}
