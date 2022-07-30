using Microsoft.EntityFrameworkCore;
using StoreWebAPI.Models;

namespace StoreWebAPI.Data.DAL
{
    public class ShoppingCartItemDAL : IShoppingCartItem
    {
        public readonly DataContext _context;
        public ShoppingCartItemDAL(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ShoppingCartItem>> CartItemGetById(int id)
        {
            var shoppingCartItemDal = await _context.ShoppingCartItems
                .Include(s=>s.ShoppingCart)
                .Where(i => i.ShoppingCartId == id)
                .Include(i => i.Product)
                .Where(i => i.ProductId == i.ProductId)
                .ToListAsync();
            if (shoppingCartItemDal == null)
                throw new Exception($"Data Shopping Cart Item Dengan Id {id} Tidak Ditemukan");
            return shoppingCartItemDal;
        }

        public async Task Delete(int id)
        {
            var shoppingCartItem = await _context.ShoppingCartItems
                .Where(i => i.ShoppingCartId == id)
                .ToListAsync();

            if (shoppingCartItem == null)
                throw new Exception($"Data Shopping Cart Item Dengan Id {id} Tidak Ditemukan");
            _context.ShoppingCartItems.RemoveRange(shoppingCartItem);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ShoppingCartItem>> GetAll()
        {
            var shoppingCartItemDal = await _context.ShoppingCartItems
                .Include(i=>i.Product)
                .Include(i=>i.ShoppingCart)
                .ThenInclude(j=>j.Customer)
                .OrderBy(i=>i.Product.Id)
                .ToListAsync();
            return shoppingCartItemDal;
        }

        public Task<IEnumerable<ShoppingCartItem>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShoppingCartItem>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ShoppingCartItem> Insert(ShoppingCartItem obj)
        {
            try
            {   
                if (obj.Quatity <= 0)
                    throw new Exception("Quatity : Tidak Boleh Kosong");
                else
                    _context.ShoppingCartItems.Add(obj);
                    await _context.SaveChangesAsync();
                    return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<ShoppingCartItem> Update(ShoppingCartItem obj)
        {
            try
            {
                var updateShoppingCartItem = await _context.ShoppingCartItems
                    .FirstOrDefaultAsync(i => i.Id == obj.Id);
                if (updateShoppingCartItem == null)
                    throw new Exception($"Shopping CartI tem Dengan Id {obj.Id} Tidak Ditemukan");

                updateShoppingCartItem.Quatity = obj.Quatity;
                updateShoppingCartItem.ProductId = obj.ProductId;
                updateShoppingCartItem.ShoppingCartId = obj.ShoppingCartId;
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        Task<ShoppingCartItem> ICrud<ShoppingCartItem>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
