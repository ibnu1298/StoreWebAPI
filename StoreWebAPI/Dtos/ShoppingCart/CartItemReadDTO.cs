using StoreWebAPI.Dtos.Product;

namespace StoreWebAPI.Dtos.ShoppingCart
{
    public class CartItemReadDTO
    {
        public int Id { get; set; }
        public int Quatity { get; set; }
        public CartItemProductDTO Product { get; set; }
    }
}
