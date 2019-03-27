using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using FoodDelivery.Data;
using FoodDelivery.Data.Models;
using FoodDelivery.Services.Contracts;

namespace FoodDelivery.Services
{
    public class CartService : ICartService
    {
        private const int DEFAULT_QUANTITY = 1;

        private readonly FoodDeliveryContext _db;
        private readonly IProductsService _productService;
        private readonly IUserService _userService;

        public CartService(FoodDeliveryContext db,
            IProductsService productService,
            IUserService userService)
        {
            this._db = db;
            this._productService = productService;
            this._userService = userService;
        }

        public void AddProductInCart(string productId, string username, int? quntity = null)
        {
            var product = this._productService.GetProductById(productId);
            var user = this._userService.GetUserByUsername(username);

            if (product == null || user == null)
            {
                return;
            }

            var cartProduct = GetCartProduct(productId, user.CartId);

            if (cartProduct != null)
            {
                return;
            }

            cartProduct = new CartProduct
            {
                Product = product,
                Quantity = quntity == null ? DEFAULT_QUANTITY : quntity.Value,
                CartId = user.CartId
            };

            this._db.CartProducts.Add(cartProduct);
            this._db.SaveChanges();
        }

        private CartProduct GetCartProduct(string productId, string cartId)
        {
            return this._db.CartProducts.FirstOrDefault(x => x.CartId == cartId && x.ProductId == productId);
        }

        public void EditProductQuantityInCart(string productId, string username, int quantity)
        {
            var product = this._productService.GetProductById(productId);
            var user = this._userService.GetUserByUsername(username);

            if (product == null || user == null || quantity <= 0)
            {
                return;
            }

            var cartProduct = this.GetCartProduct(productId, user.CartId);

            if (cartProduct == null)
            {
                return;
            }

            cartProduct.Quantity = quantity;

            this._db.Update(cartProduct);
            this._db.SaveChanges();
        }

        public IEnumerable<CartProduct> GetAllCartProducts(string username)
        {
            var user = this._userService.GetUserByUsername(username);

            if (user == null)
            {
                return null;
            }

            return this._db.CartProducts.Include(x => x.Cart)
                .Include(x => x.Product)
                .Where(x => x.Cart.User.UserName == username).ToList();
        }

        public void DeleteProductFromCart(string id, string username)
        {
            var product = this._productService.GetProductById(id);
            var user = this._userService.GetUserByUsername(username);

            if (product == null || user == null)
            {
                return;
            }

            var shoppingCart = GetCartProduct(product.Id, user.CartId);

            this._db.CartProducts.Remove(shoppingCart);
            this._db.SaveChanges();
        }

        public void DeleteAllProductFromCart(string username)
        {
            var user = this._userService.GetUserByUsername(username);

            if (user == null)
            {
                return;
            }

            var cartProducts = this._db.CartProducts.Where(x => x.CartId == user.CartId);

            this._db.CartProducts.RemoveRange(cartProducts);
            this._db.SaveChanges();
        }

        public bool AnyProducts(string username)
        {
            return this._db.CartProducts.Any(x => x.Cart.User.UserName == username);
        }
    }
}
