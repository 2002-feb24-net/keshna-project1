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
        public string Name { get; set; }
        public DateTime Date { get; set; }

        [DisplayName("Cup-Cake Name")]
        public string Pname { get; set; }
        public decimal Price { get; set; }
    }
}
