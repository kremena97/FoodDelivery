using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FoodDelivery.Services.Contracts;
using FoodDelivery.Web.Areas.Menu.Models;

namespace FoodDelivery.Web.Areas.Products.Controllers
{
    [Area("Products")]
    public class ProductsController : Controller
    {
        private const string DEFAULT_CATEGORY = "Salads";
        private readonly IProductsService _productsService;
        private readonly IMapper _mapper;

        public ProductsController(IProductsService productsService,IMapper mapper)
        {
            this._productsService = productsService;
            this._mapper = mapper;
        }

        public IActionResult Menu()
        {
            MenuViewModel model = new MenuViewModel();
            var products = _productsService.GetAllProductsByCategory(DEFAULT_CATEGORY);
            var categories = _productsService.GetAllCategories();

            if (products == null)
            {
                return NotFound();
            }

            var productViewModel = _mapper.Map<IList<ProductsViewModel>>(products);
            var categoriesViewModel = _mapper.Map<IList<CategoriesViewModel>>(categories);

            model.Products = productViewModel;
            model.Categories = categoriesViewModel;

            return View(model);
        }

        [HttpPost]
        public IActionResult Menu(MenuViewModel model)
        {
            var products = _productsService.GetAllProductsByCategory(DEFAULT_CATEGORY);
            var categories = _productsService.GetAllCategories();

            if (products == null)
            {
                return NotFound();
            }

            var productViewModel = _mapper.Map<IList<ProductsViewModel>>(products);
            var categoriesViewModel = _mapper.Map<IList<CategoriesViewModel>>(categories);

            model.Products = productViewModel;
            model.Categories = categoriesViewModel;

            return View(model);
        }

        public IActionResult Details(string id)
        {
            var product = _productsService.GetProductById(id);
            var productViewModel = _mapper.Map<ProductsViewModel>(product);
            return View(productViewModel);
        }
    }
}