using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Web.Areas.Orders.Controllers
{
    [Area("Orders")]
    public class OrdersController : Controller
    {
        public OrdersController()
        {
            
        }
        
        public IActionResult Create()
        {
            return View();
        }
    }
}