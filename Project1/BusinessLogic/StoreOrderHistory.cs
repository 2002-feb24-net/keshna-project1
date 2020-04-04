using System;

namespace BusinessLogic
{
    public class StoreOrderHistory
    {
        public int OrderID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Pname { get; set; }
        public decimal Price { get; set; }
        public int InventoryAmount { get; set; }
    }
}
