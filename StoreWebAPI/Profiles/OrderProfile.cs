using AutoMapper;
using StoreWebAPI.Dtos.Order;
using StoreWebAPI.Models;

namespace StoreWebAPI.Profiles 
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderReadDTO>();
            CreateMap<OrderReadDTO, Order>();
        }
    }
}
