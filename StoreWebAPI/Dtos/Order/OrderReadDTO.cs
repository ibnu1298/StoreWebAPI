namespace StoreWebAPI.Dtos.Order
{
    public class OrderReadDTO
    {
        public int Id { get; set; }
        public string Methode { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
