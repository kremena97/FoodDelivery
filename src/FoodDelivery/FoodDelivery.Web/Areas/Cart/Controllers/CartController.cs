using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FoodDelivery.Services.Contracts;
using FoodDelivery.Web.Areas.Cart.Models;
using System.Linq;

namespace FoodDelivery.Web.Areas.Cart.Controllers
{
    [Area("Cart")]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;


        public CartController(ICartService cartService,
            IMapper mapper)
        {
            this._cartService = cartService;
            this._mapper = mapper;
        }

        public IActionResult ViewCart()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var cartProducts = this._cartService.GetAllCartProducts(this.User.Identity.Name).ToList();

                if (!cartProducts.Any())
                {
                    return RedirectToAction("Index", "Home");
                }
                
                var cartViewModel = new CartViewModel()
                {
                    CartItems = cartProducts.Select(x=> new CartItemsViewModel()
                    {
                        Id = x.ProductId,
                        ImageUrl = x.Product.Picture,
                        Name = x.Product.Name,
                        Price = x.Product.Price.ToString("F2"),
                        Quantity = x.Quantity,
                        Total = (x.Quantity * x.Product.Price).ToString("F2"),
                        TotalDecimal = x.Quantity * x.Product.Price
                    }).ToList(),
                    
                };

                cartViewModel.Total = cartViewModel.CartItems.Select(x => x.TotalDecimal).Sum().ToString("F2");
                
                return this.View(cartViewModel);
            }
            return View();
        }

        public IActionResult Add(string id, bool direct)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                this._cartService.AddProductInCart(id, this.User.Identity.Name);
            }
            else
            {
                return this.Redirect("Login.aspx"); 
            }
            
            return this.Redirect("/Products/Products/Menu");
        }

        public IActionResult Delete(string id)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                this._cartService.DeleteProductFromCart(id, this.User.Identity.Name);

                return this.RedirectToAction(nameof(ViewCart));
            }
            
            return this.Redirect("Login.aspx");
        }

        public IActionResult Edit(string id, int quantity)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                this._cartService.EditProductQuantityInCart(id, this.User.Identity.Name, quantity);

                return this.RedirectToAction(nameof(ViewCart));
            }

            return this.Redirect("Login.aspx");
        }
    }
}