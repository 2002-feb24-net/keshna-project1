using System;

namespace BusinessLogic
{
    public class CustomerOrderHistory
    {
        public int LocationID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Pname { get; set; }
        public decimal Price { get; set; }
    }
}
