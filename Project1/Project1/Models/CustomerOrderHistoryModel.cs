using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Project1.Models
{
    public class CustomerOrderHistoryModel
    {
        [Required]
        [DisplayName("Location ID")]
        public int LocationID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DisplayName("Cup-Cake Name")]
        public string Pname { get; set; }
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
