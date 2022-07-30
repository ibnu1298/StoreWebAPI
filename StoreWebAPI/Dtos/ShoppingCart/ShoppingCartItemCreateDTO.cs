namespace StoreWebAPI.Dtos.ShoppingCart
{
    public class ShoppingCartItemCreateDTO
    {
        public int Quatity { get; set; }
        public int ProductId { get; set; }
        public int ShoppingCartId { get; set; }
    }
}
