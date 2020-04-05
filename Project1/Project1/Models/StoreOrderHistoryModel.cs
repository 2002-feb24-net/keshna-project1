using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Project1.Models
{
    public class StoreOrderHistoryModel
    {
        [Required]
        public int OrderID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Cup-Cake Name")]
        public string Pname { get; set; }
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Required]
        [DisplayName("Stock")]
        public int InventoryAmount { get; set; }
    }
}
