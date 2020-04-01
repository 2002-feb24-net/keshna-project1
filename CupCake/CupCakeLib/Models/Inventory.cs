using System;
using System.Collections.Generic;
using System.Text;

namespace CupCakeLib.Models
{
    // optional. Dont think inventory is required
    public class Inventory
    {
        public int InventoryId { get; set; }
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
