using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWebAPI.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public int Quatity { get; set; }
        public int ProductId { get; set; }
        public int ShoppingCartId { get; set; }
        public Product Product { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
