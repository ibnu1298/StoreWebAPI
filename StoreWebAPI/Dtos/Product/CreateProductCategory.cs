using StoreWebAPI.Models;

namespace StoreWebAPI.Dtos.Product
{
    public class CreateProductCategory
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public CreateDTO Category { get; set; }
    }
}
