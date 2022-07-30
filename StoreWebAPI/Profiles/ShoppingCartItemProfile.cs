using AutoMapper;
using StoreWebAPI.Models;
using StoreWebAPI.Dtos.ShoppingCart;
using StoreWebAPI.Dtos.ShoppingCartDtos;

namespace StoreWebAPI.Profiles
{
    public class ShoppingCartItemProfile : Profile
    {
        public ShoppingCartItemProfile()
        {
            CreateMap<ShoppingCartItem, ShoppingCartItemReadDTO>();
            CreateMap<ShoppingCartItemReadDTO, ShoppingCartItem>();

            CreateMap<ShoppingCartItem, ShoppingCartItemCreateDTO>();
            CreateMap<ShoppingCartItemCreateDTO, ShoppingCartItem>();

            CreateMap<CartItemReadDTO, ShoppingCartItem>();
            CreateMap<ShoppingCartItem, CartItemReadDTO>();

            CreateMap<ShoppingCartItem, ShoppingCartItemUpdateDTO>();
            CreateMap<ShoppingCartItemUpdateDTO, ShoppingCartItem>();
            
        }
    }
}
