using AutoMapper;
using StoreWebAPI.Dtos.Address;
using StoreWebAPI.Dtos.Customer;
using StoreWebAPI.Models;

namespace StoreWebAPI.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<CreateAddressDTO, Address>();
            CreateMap<Address, CreateAddressDTO>();

            CreateMap<Address, ReadAddressDTO>();
            CreateMap<ReadAddressDTO, Address>();

            CreateMap<UpdateAddressDTO, Address>();
            CreateMap<Address, UpdateAddressDTO>();

            CreateMap<Address, UpdateCustAddressDTO>();
            CreateMap<UpdateCustAddressDTO, Address>();
        }
    }
}
