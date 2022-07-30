using StoreWebAPI.Models;

namespace StoreWebAPI.Data.DAL
{
    public interface IShoppingCart : ICrud<ShoppingCart>
    {
        Task<IEnumerable<ShoppingCart>> GetShopingCartWithCustomer();

    }
}
