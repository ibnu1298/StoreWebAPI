namespace StoreWebAPI.Dtos.Address
{
    public class ReadAddressDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double NumberPhone { get; set; }
        public string Street { get; set; }
        public int PostalCode { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
    }
}
