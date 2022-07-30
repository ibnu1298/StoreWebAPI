namespace StoreWebAPI.Models
{
    public class Address
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Street { get; set; }
        public int PostalCode { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public Customer Customer { get; set; }
    }
}
