using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWebAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Methode { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public int ShoppingCartId { get; set; }
    }
}
