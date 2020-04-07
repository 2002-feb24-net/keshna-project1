using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class OrderDetails
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int InventoryId { get; set; }

        public virtual Inventory Inventory { get; set; }
        public virtual Orders Order { get; set; }
    }
}
