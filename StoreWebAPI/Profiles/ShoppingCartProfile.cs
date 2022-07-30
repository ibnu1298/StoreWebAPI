using AutoMapper;
using StoreWebAPI.Dtos.Customer;
using StoreWebAPI.Models;
using StoreWebAPI.Dtos.ShoppingCart;

namespace StoreWebAPI.Profiles
{
    public class ShoppingCartProfile : Profile
    {
        public ShoppingCartProfile()
        {
            CreateMap<ShoppingCart, ShoppingCartReadDTO>();
            CreateMap<ShoppingCartReadDTO, ShoppingCart>();

            CreateMap<ShoppingCart, ShoppingCartCreateDTO>();
            CreateMap<ShoppingCartCreateDTO, ShoppingCart>();

            CreateMap<ShoppingCart, CartShoppingCartDTO>();
            CreateMap<CartShoppingCartDTO, ShoppingCart>();

            CreateMap<ShoppingCartRead, ShoppingCart>();
            CreateMap<ShoppingCart, ShoppingCartRead>();
            
            CreateMap<ShoppingCartCustomerReadDTO, ShoppingCart>();
            CreateMap<ShoppingCart, ShoppingCartCustomerReadDTO>();

        }

    }
}
