using System;
using System.Collections.Generic;

namespace CupCakeData.Entities
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime OrderTime { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Location Location { get; set; }
        public virtual Product Product { get; set; }
    }
}
