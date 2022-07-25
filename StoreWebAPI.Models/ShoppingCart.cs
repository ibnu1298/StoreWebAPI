namespace StoreWebAPI.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public Order Order { get; set; }
    }
}
