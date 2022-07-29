using StoreWebAPI.Models;

namespace StoreWebAPI.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public double NumberPhone { get; set; }
        public string Email { get; set; }
        public double Balance { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(Customer cust, string token)
        {
            Id = cust.Id;
            Name = cust.Name;
            Gender = cust.Gender;
            NumberPhone = cust.NumberPhone;
            Email = cust.Email;
            Balance = cust.Balance;
            Token = token;
        }
    }
}