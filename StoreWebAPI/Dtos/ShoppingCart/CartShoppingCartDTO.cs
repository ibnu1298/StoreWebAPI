using StoreWebAPI.Dtos.Customer;

namespace StoreWebAPI.Dtos.ShoppingCart
{
    public class CartShoppingCartDTO
    {
        public int ShoppingCartId { get; set; }
        public CustomerCartReadDTO Customer { get; set; }
    }
}
