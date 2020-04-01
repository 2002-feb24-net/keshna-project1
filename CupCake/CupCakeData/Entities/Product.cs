using System;
using System.Collections.Generic;

namespace CupCakeData.Entities
{
    public partial class Product
    {
        public Product()
        {
            Inventory = new HashSet<Inventory>();
            Orders = new HashSet<Orders>();
        }

        public int ProductId { get; set; }
        public string Pname { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
