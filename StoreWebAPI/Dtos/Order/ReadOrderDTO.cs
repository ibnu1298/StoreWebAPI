namespace StoreWebAPI.Dtos.Order
{
    public class ReadOrderDTO
    {
        public int OrderId { get; set; }
        public string StatusPayment { get; set; }
        public int ShoppingCartId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
