using Microsoft.EntityFrameworkCore;
using StoreWebAPI.Models;

namespace StoreWebAPI.Data.DAL
{
    public class ShoppingCartDAL : IShoppingCart
    {
        public readonly DataContext _context;
        public ShoppingCartDAL(DataContext context)
        {
            _context = context;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ShoppingCart>> GetAll()
        {
            var shoppingCartDal = await _context.ShoppingCarts
                .Include(i=>i.Customer)
                .Include(i => i.ShoppingCartItem.ToList().Where(k => k.ShoppingCart == k.ShoppingCart))
                .ThenInclude(i=>i.Product)
                .OrderBy(i => i.CustomerId)
                .ToListAsync();
            return shoppingCartDal;
        }

        public Task<ShoppingCart> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShoppingCart>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ShoppingCart>> GetShopingCartWithCustomer()
        {
            var ShoppingCart = await _context.ShoppingCarts
                .Include(s => s.Customer)
                .ToListAsync();
            return ShoppingCart;
        }

        public async Task<ShoppingCart> Insert(ShoppingCart obj)
        {
            try
            {
                _context.ShoppingCarts.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public Task<ShoppingCart> Update(ShoppingCart obj)
        {
            throw new NotImplementedException();
        }
    }
}
