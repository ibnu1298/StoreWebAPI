namespace StoreWebAPI.Dtos.ShoppingCartDtos
{
    public class ShoppingCartItemUpdateDTO
    {
        public int Id { get; set; }
        public int Quatity { get; set; }
        public int ProductId { get; set; }
        public int ShoppingCartId { get; set; }
    }
}
