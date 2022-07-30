using StoreWebAPI.Dtos.Customer;

namespace StoreWebAPI.Dtos.ShoppingCart
{
    public class ShoppingCartCustomerReadDTO
    {
        public int ShoppingCartId { get; set; }
        public int CustomerId { get; set; }
        public CustomerCartReadDTO Customer { get; set; }
    }
}
