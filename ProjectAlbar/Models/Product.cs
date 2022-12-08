using System;
using System.Collections.Generic;

//#nullable disable

namespace ProjectAlbar.Models
{
    public partial class Product
    {
        public Product()
        {
            // OrderItems = new HashSet<OrderItem>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public int UnitsInStock { get; set; }

    }
}
