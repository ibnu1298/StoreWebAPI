namespace StoreWebAPI.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public double NumberPhone { get; set; }
        public double Balance { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public List<Address> Addresses { get; set; } = new List<Address>();
    }
}
