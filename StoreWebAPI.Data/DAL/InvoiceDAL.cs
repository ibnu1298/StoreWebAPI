using Microsoft.EntityFrameworkCore;
using StoreWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWebAPI.Data.DAL
{
    public class InvoiceDAL : IInvoice
    {
        private readonly DataContext _context;

        public InvoiceDAL(DataContext context)
        {
            _context = context;
        }
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Invoice>> GetAll()
        {
            var results = await _context.Invoices
                .Include(x => x.Order)
                .OrderBy(i => i.Order.OrderDate)
                .ToListAsync();
            return results;
        }

        public Task<Invoice> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Invoice>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Invoice> Insert(Invoice obj)
        {
            var orderCart = _context.Orders
                .FirstOrDefault(i => i.OrderId == obj.OrderId);
            try
            {
                _context.Invoices.Add(obj);
                _context.Orders.Remove(orderCart);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public Task<Invoice> Update(Invoice obj)
        {
            throw new NotImplementedException();
        }
    }
}
