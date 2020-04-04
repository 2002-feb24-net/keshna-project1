using System.Collections.Generic;


namespace Project1.Models
{
    public class OrderProductModel
    {
        public int CustomerID { get; set; }
        public int LocationID { get; set; }

        public List<ProductModel> products { get; set; } = new List<ProductModel>();
    }
}
