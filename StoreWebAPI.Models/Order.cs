﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWebAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string StatusPayment { get; set; }
        public int ShoppingCartId { get; set; }
        public DateTime OrderDate { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
