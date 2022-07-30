using StoreWebAPI.Dtos.Order;

namespace StoreWebAPI.Dtos.Invoice
{
    public class InvoiceReadDTO
    {
        public int InvoiceId { get; set; }
        public int OrderId { get; set; }
        public ReadOrderDTO Order { get; set; }
    }
}
