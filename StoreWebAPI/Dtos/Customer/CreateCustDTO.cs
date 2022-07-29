namespace StoreWebAPI.Dtos.Customer
{
    public class CreateCustDTO
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public double NumberPhone { get; set; }
        public double Balance { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
