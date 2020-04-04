using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Stores
    {
        public Stores()
        {
            Inventory = new HashSet<Inventory>();
            Orders = new HashSet<Orders>();
        }

        public int LocationId { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
