using AutoMapper;
using StoreWebAPI.Dtos.Customer;
using StoreWebAPI.Models;

namespace StoreWebAPI.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreateCustDTO, Customer>();

            CreateMap<ReadCustDTO, Customer>();
            CreateMap<Customer, ReadCustDTO>();

            CreateMap<Customer, ReadCustAddressDTO>();
            CreateMap<ReadCustAddressDTO, Customer>();
        }
    }
}
