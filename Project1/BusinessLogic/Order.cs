using System;


namespace BusinessLogic
{
    public class Order
    {
        public DateTime OrderDate { get; set; }
        public int OrderId { get; set; }
        public int StoreId { get; set; }
        public int CustomerId { get; set; }

        public Order()
        {
            this.OrderDate = DateTime.Now;
        }
    }
}
