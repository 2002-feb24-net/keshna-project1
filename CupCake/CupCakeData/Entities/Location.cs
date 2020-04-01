using System;
using System.Collections.Generic;

namespace CupCakeData.Entities
{
    public partial class Location
    {
        public Location()
        {
            Inventory = new HashSet<Inventory>();
            Orders = new HashSet<Orders>();
        }

        public int LocationId { get; set; }
        public string City { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
