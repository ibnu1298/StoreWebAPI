namespace StoreWebAPI.Dtos.Product
{
    public class CreateProductDTO
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}
