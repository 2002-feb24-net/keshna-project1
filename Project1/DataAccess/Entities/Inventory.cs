using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Inventory
    {
        public Inventory()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public int LocationId { get; set; }
        public int InventoryAmount { get; set; }

        public virtual Stores Location { get; set; }
        public virtual Products Product { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
