using System.Collections.Generic;
using FoodDelivery.Data.Models;

namespace FoodDelivery.Services.Contracts
{
    public interface ICartService
    {
        void AddProductInCart(string productId, string username, int? quntity = null);

        void EditProductQuantityInCart(string productId, string username, int quantity);

        IEnumerable<CartProduct> GetAllCartProducts(string username);

        void DeleteProductFromCart(string id, string username);

        void DeleteAllProductFromCart(string username);

        bool AnyProducts(string username);
    }
}
