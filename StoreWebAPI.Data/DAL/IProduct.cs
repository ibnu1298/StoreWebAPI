using StoreWebAPI.Models;

namespace StoreWebAPI.Data.DAL
{
    public interface IProduct : ICrud<Product>
    {
        Task<IEnumerable<Product>> GetProductWithCategory();
        Task<IEnumerable<Product>> Pagination();
        Task<Product> AddProductWithCategory(Product product);
        Task<IEnumerable<Product>> GetByCategory(string name);
        Task<IEnumerable<Product>> GetByPrice(double price);
        Task<IEnumerable<Product>> GetByPriceToLow(double price);
        Task<IEnumerable<Product>> GetByPriceToHigh(double price);
        Task<IEnumerable<Product>> HighToLow();
        Task<IEnumerable<Product>> LowToHigh();
    }
}
