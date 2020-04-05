using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Project1.Models
{
    public class StoreOrderHistoryModel
    {
        [Required]
        public int OrderID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        [Display(Name = "Cup-Cake Name")]
        public string Pname { get; set; }
        public decimal Price { get; set; }
        [Required]
        [DisplayName("Stock")]
        public int InventoryAmount { get; set; }
    }
}
