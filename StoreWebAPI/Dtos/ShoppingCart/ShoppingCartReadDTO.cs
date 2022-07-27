using StoreWebAPI.Dtos.Order;
namespace StoreWebAPI.Dtos.ShoppingCart
{
    public class ShoppingCartReadDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public OrderReadDTO Order { get; set; }
    }
}
