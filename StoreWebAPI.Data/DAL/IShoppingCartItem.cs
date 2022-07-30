using StoreWebAPI.Models;

namespace StoreWebAPI.Data.DAL
{
    public interface IShoppingCartItem : ICrud<ShoppingCartItem>
    {
        Task<IEnumerable<ShoppingCartItem>> CartItemGetById(int id);
    }
}
