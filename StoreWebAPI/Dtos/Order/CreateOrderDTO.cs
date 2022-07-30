namespace StoreWebAPI.Dtos.Order
{
    public class CreateOrderDTO
    {
        public string StatusPayment { get; set; }
        public int ShoppingCartId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
