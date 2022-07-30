using AutoMapper;
using StoreWebAPI.Dtos.Invoice;
using StoreWebAPI.Models;
namespace StoreWebAPI.Profiles
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<Invoice, InvoiceReadDTO>();
            CreateMap<InvoiceReadDTO, Invoice>();

            CreateMap<InvoiceCreateDTO, Invoice>();
            CreateMap<Invoice, InvoiceCreateDTO>();
        }
    }
}
