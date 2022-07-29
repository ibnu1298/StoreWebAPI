using StoreWebAPI.Dtos.Address;

namespace StoreWebAPI.Dtos.Customer
{
    public class ReadCustAddressDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public double NumberPhone { get; set; }
        public double Balance { get; set; }
        public string Email { get; set; }
    }
}
