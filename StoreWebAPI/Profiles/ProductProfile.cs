using AutoMapper;
using StoreWebAPI.Dtos.Product;
using StoreWebAPI.Models;

namespace StoreWebAPI.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductDTO, Product>();
            CreateMap<CreateProductCategory, Product>();
            CreateMap<UpdateProductCategoryDTO, Product>();

            CreateMap<ReadProductDTO, Product>();
            CreateMap<Product, ReadProductDTO>();

            CreateMap<Product, ReadProductCategoryDTO>();
            CreateMap<ReadProductCategoryDTO, Product>();
        }
    }
}
