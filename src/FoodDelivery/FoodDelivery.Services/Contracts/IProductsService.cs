using FoodDelivery.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace FoodDelivery.Services.Contracts
{
    public interface IProductsService
    {
        Product GetProductById(string productId);

        IEnumerable<Category> GetAllCategories();

        IQueryable<Product> GetAllProductsByCategory(string category);

        Category GetCategory(string id);
    }
}
