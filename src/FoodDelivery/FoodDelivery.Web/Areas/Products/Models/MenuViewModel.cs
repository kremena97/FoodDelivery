using System.Collections.Generic;

namespace FoodDelivery.Web.Areas.Menu.Models
{
    public class MenuViewModel
    {
        public IList<ProductsViewModel> Products { get; set; }

        public IList<CategoriesViewModel> Categories { get; set; }

        public string DisplayCategory { get; set; }
    }
}
