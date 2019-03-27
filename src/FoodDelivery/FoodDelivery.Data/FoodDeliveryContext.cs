using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FoodDelivery.Data.Models;

namespace FoodDelivery.Data
{
    public class FoodDeliveryContext : IdentityDbContext<FoodDeliveryUser>
    {
        public FoodDeliveryContext(DbContextOptions<FoodDeliveryContext> options)
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

        public DbSet<CategoryProducts> CategoryProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrderProduct>().HasKey(x => new { x.OrderId, x.ProductId });

            builder.Entity<CartProduct>().HasKey(x => new { x.ProductId, x.CartId });

            builder.Entity<CategoryProducts>().HasKey(x => new { x.ProductId, x.CategoryId });
            base.OnModelCreating(builder);
        }
    }
}
