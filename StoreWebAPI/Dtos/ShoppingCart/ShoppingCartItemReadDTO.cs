namespace StoreWebAPI.Dtos.ShoppingCart
{
    public class ShoppingCartItemReadDTO
    {
        public int Id { get; set; }
        public int Quatity { get; set; }
        public CartProductDTO Product { get; set; }
        public CartShoppingCartDTO ShoppingCart { get; set; }
    }
}
