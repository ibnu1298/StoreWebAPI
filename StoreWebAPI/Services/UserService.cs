using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StoreWebAPI.Helpers;
using StoreWebAPI.Models;
using StoreWebAPI.Data;
using StoreWebAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StoreWebAPI.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        Task<Customer> Registration(Customer cust);
        Task<Customer> Update(Customer cust);
        AuthenticateResponse Login(AuthenticateRequest model);

    }
    public class UserService : IUserService
    {
        private List<Customer> _customer = new List<Customer>
        {
            new Customer { Id = 1, Name = "Test", Gender = "User", NumberPhone = 6257,Balance = 9090909090, Email = "WiroSableng212", Password = "1234" }
        };

        private readonly AppSettings _appSettings;
        private readonly DataContext _context;

        public UserService(IOptions<AppSettings> appSettings, DataContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var cust = _customer.SingleOrDefault(x => x.Email == model.Email && x.Password == model.Password);

            // return null if user not found
            if (cust == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(cust);

            return new AuthenticateResponse(cust, token);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers;
        }

        public Customer GetById(int id)
        {
            return _context.Customers.FirstOrDefault(x => x.Id == id);
        }

        private string generateJwtToken(Customer user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1),//hanya berlaku 1 Hari
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<Customer> Registration(Customer obj)
        {
            try
            {
                var userName = _context.Customers.FirstOrDefault(c => c.Email == obj.Email);
                if (userName != null) throw new ("Email sudah Terdaftar");
                _context.Customers.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
        }

        public AuthenticateResponse Login(AuthenticateRequest model)
        {
            var cust = _context.Customers.SingleOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            // return null if user not found
            if (cust == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(cust);

            return new AuthenticateResponse(cust, token);
        }

        public async Task<Customer> Update(Customer cust)
        {
            try
            {
                var updateBio = await _context.Customers.Include(c => c.Addresses).FirstOrDefaultAsync(c => c.Id == cust.Id);
                if (updateBio == null) throw new($"Data Customer dengan Id {cust.Id} Tidak ditemukan");
                updateBio.Name = cust.Name;
                updateBio.Gender = cust.Gender;
                updateBio.NumberPhone = cust.NumberPhone;
                updateBio.Balance = cust.Balance;
                updateBio.Email = cust.Email;
                updateBio.Addresses = cust.Addresses;
                await _context.SaveChangesAsync();
                return cust;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}