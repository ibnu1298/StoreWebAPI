using AutoMapper;
using StoreWebAPI.Dtos.ShoppingCart;
using StoreWebAPI.Models;

namespace StoreWebAPI.Profiles
{
    public class ShoppingCartProfile : Profile
    {
        public ShoppingCartProfile()
        {
            CreateMap<ShoppingCart, ShoppingCartReadDTO>();
            CreateMap<ShoppingCartReadDTO, ShoppingCart>();
        }

    }
}
