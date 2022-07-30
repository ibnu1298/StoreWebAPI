using AutoMapper;
using StoreWebAPI.Dtos.Order;
using StoreWebAPI.Models;

namespace StoreWebAPI.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<ReadOrderDTO, Order>();
            CreateMap<Order, ReadOrderDTO>();

            CreateMap<Order, CreateOrderDTO>();
            CreateMap<CreateOrderDTO, Order>();
        }
    }
}
