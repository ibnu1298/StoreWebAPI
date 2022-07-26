using Microsoft.EntityFrameworkCore;
using StoreWebAPI.Models;

namespace StoreWebAPI.Data.DAL
{
    public class ProductDAL : IProduct
    {
        private readonly DataContext _context;

        public ProductDAL(DataContext context)
        {
            _context = context;
        }
        public async Task<Product> AddProductWithCategory(Product product)
        {
            try
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var delete = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (delete == null) throw new Exception($"Data Product dengan Id {id} tidak Ditemukan");
                _context.Products.Remove(delete);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var results = await _context.Products.OrderBy(p => p.Id).ToListAsync();
            return results;
        }

        public async Task<IEnumerable<Product>> GetByCategory(string category)
        {
            var results = await _context.Products.Include(p => p.Category).Where(c => c.Category.Name.Contains(category)).OrderBy(p => p.Price).ToListAsync();
            return results;
        }

        public async Task<Product> GetById(int id)
        {
            var result = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (result == null) throw new Exception($"Tidak ada data dengan Id = {id}");
            return result;
        }

        public async Task<IEnumerable<Product>> GetByName(string name)
        {
            var results = await _context.Products.Where(p => p.Name.Contains(name)).OrderByDescending(p => p.Name).ToListAsync();
            return results;
        }

        public async Task<IEnumerable<Product>> GetByPrice(double price)
        {
            var results = await _context.Products.Where(p => p.Price == price).OrderByDescending(p => p.Price).ToListAsync();
            return results;
        }

        public async Task<IEnumerable<Product>> GetByPriceToHigh(double price)
        {
            var results = await _context.Products.Where(p => p.Price >= price).OrderBy(p => p.Price).ToListAsync();
            return results;
        }

        public async Task<IEnumerable<Product>> GetByPriceToLow(double price)
        {
            var results = await _context.Products.Where(p => p.Price <= price).OrderByDescending(p => p.Price).ToListAsync();
            return results;
        }

        public async Task<IEnumerable<Product>> GetProductWithCategory()
        {
            var results = await _context.Products.Include(p => p.Category).OrderBy(p => p.Price).ToListAsync();
            return results;
        }

        public async Task<IEnumerable<Product>> HighToLow()
        {
            var results = await _context.Products.OrderByDescending(p => p.Price).ToListAsync();
            return results;
        }

        public async Task<Product> Insert(Product obj)
        {
            try
            {
                _context.Products.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<IEnumerable<Product>> LowToHigh()
        {
            var results = await _context.Products.OrderBy(p => p.Price).ToListAsync();
            return results;
        }

        public Task<IEnumerable<Product>> Pagination()
        {
            throw new NotImplementedException();
        }

        public Task<Product> Update(Product obj)
        {
            throw new NotImplementedException();
        }
    }
}
