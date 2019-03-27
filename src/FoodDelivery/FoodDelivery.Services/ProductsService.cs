using FoodDelivery.Data.Contracts;
using FoodDelivery.Data.Models;
using FoodDelivery.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace FoodDelivery.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IRepository<Product> _productsRepository;
        private readonly IRepository<Category> _categoriesRepository;

        public ProductsService(IRepository<Product> productsRepository, IRepository<Category> categoriesRepository)
        {
            this._productsRepository = productsRepository;
            this._categoriesRepository = categoriesRepository;
        }

        public Product GetProductById(string productId)
        {
            var product = this._productsRepository.All().FirstOrDefault(x => x.Id == productId);

            return product;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return this._categoriesRepository.All().ToList();
        }

        public IQueryable<Product> GetAllProductsByCategory(string category)
        {
            return this._productsRepository.All().Where(p => p.Category.Name.ToString() == category);
        }

        public Category GetCategory(string id)
        {
            return this._categoriesRepository.All().FirstOrDefault(c => c.Id == id);
        }
    }
}
