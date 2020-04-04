using System;
using System.ComponentModel.DataAnnotations;

namespace Project1.Models
{
    public class CustomerOrderHistoryModel
    {
        [Required]
        [Display(Name = "Location ID")]
        public int LocationID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        [Display(Name = "Cup-Cake Name")]
        public string Pname { get; set; }
        public decimal Price { get; set; }
    }
}
