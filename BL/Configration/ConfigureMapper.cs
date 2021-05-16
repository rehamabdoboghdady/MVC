using AutoMapper;
using BL.ViewModel;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Configration
{
    public static class ConfigureMapper
    {
        public static IMapper mapper { get; set; }
        static ConfigureMapper()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Product, ProductViewModel>().ReverseMap();
                    cfg.CreateMap<Category, CategoryViewModel>().ReverseMap();
                    cfg.CreateMap<OrderDetails, OrderDetailesViewModel>().ReverseMap();
                    cfg.CreateMap<Order, OrderDetailsViewModel>().ReverseMap();
                    cfg.CreateMap<ApplicationUserIdentity, LoginViewModel>().ReverseMap();
                    cfg.CreateMap<ApplicationUserIdentity, RegisterViewModel>().ReverseMap();
                 
                });
            mapper = config.CreateMapper();
        }
    }
}
