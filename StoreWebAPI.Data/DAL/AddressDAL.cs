using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreWebAPI.Models;

namespace StoreWebAPI.Data.DAL
{
    public class AddressDAL : IAddress
    {
        private readonly DataContext _context;

        public AddressDAL(DataContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            try
            {
                var delete = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == id);
                if (delete == null) throw new Exception($"Data Address dengan Id {id} tidak Ditemukan");
                _context.Addresses.Remove(delete);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<IEnumerable<Address>> GetAll()
        {
            var results = await _context.Addresses.OrderBy(a => a.Id).ToListAsync();
            return results;
        }

        public async Task<Address> GetById(int id)
        {
            var result = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == id);
            if (result == null) throw new Exception($"Tidak ada data dengan Id = {id}");
            return result;
        }

        public async Task<IEnumerable<Address>> GetByName(string name)
        {
            var results = await _context.Addresses.Where(a => a.Street.Contains(name)).OrderByDescending(a => a.Street).ToListAsync();
            return results;
        }

        public async Task<Address> Insert(Address obj)
        {
            try
            {
                _context.Addresses.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Address> Update(Address obj)
        {
            try
            {
                var updateAddress = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == obj.Id);
                if (updateAddress == null) throw new($"Data Tidak dengan Id {obj.Id} Tidak ditemukan");
                updateAddress.Street = obj.Street;
                updateAddress.PostalCode = obj.PostalCode;
                updateAddress.District = obj.District;
                updateAddress.City = obj.City;
                updateAddress.Province = obj.Province;
                updateAddress.CustomerId = obj.CustomerId;
                await _context.SaveChangesAsync();
                return obj;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
