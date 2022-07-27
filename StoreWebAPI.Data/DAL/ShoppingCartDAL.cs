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
            var data = await _context.ShoppingCarts
                .Include(i => i.Order)
                .ToListAsync();
            return data;
        }

        public Task<ShoppingCart> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShoppingCart>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCart> Insert(ShoppingCart obj)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCart> Update(ShoppingCart obj)
        {
            throw new NotImplementedException();
        }
    }
}
