using AutoMapper;
using StoreWebAPI.Dtos.Product;
using StoreWebAPI.Models;

namespace StoreWebAPI.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateDTO, Category>();

            CreateMap<ReadDTO, Category>();
            CreateMap<Category, ReadDTO>();
        }
    }
}
