using StoreWebAPI.Dtos.Customer;

namespace StoreWebAPI.Dtos.ShoppingCart
{
    public class ShoppingCartReadDTO
    {
        public int ShoppingCartId { get; set; }
        public int CustomerId { get; set; }
        public CustomerCartReadDTO Customer { get; set; }
        public List<CartItemReadDTO> ShoppingCartItem { get; set; }
    }
}
