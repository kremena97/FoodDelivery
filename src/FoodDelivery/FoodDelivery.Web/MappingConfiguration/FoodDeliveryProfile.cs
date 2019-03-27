using AutoMapper;
using FoodDelivery.Data.Models;
using FoodDelivery.Web.Areas.Menu.Models;

namespace FoodDelivery.Web.MappingConfiguration
{
    public class FoodDeliveryProfile : Profile
    {
        public FoodDeliveryProfile()
        {
            this.CreateMap<Product, ProductsViewModel>()
                .ForMember(x => x.Category, y => y.MapFrom(c => c.Category.Name))
                .ForMember(x => x.Price, y => y.MapFrom(p => p.Price.ToString("F2")));

            this.CreateMap<Category, CategoriesViewModel>();
        }
    }
}
