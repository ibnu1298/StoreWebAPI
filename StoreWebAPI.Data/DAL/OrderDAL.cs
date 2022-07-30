using Microsoft.EntityFrameworkCore;
using StoreWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWebAPI.Data.DAL
{
    public class OrderDAL : IOrder
    {
        private readonly DataContext _context;

        public OrderDAL(DataContext context)
        {
            _context = context;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            var results = await _context.Orders
                .OrderBy(i=>i.OrderDate)
                .ToListAsync();
            return results;
        }

        public Task<Order> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> Insert(Order obj)
        {
            try
            {
                var deleteShoppingCart = await _context.ShoppingCartItems
                    .Where(i=>i.ShoppingCartId == obj.ShoppingCartId)
                    .ToListAsync();

                _context.Orders.Add(obj);
                _context.ShoppingCartItems.RemoveRange(deleteShoppingCart);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public Task<Order> Update(Order obj)
        {
            throw new NotImplementedException();
        }
    }
}
