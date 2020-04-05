using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project1.Models
{
    public class InventoryModel

    {

        [Display(Name = "ID")]
        public int Id { get; set; }

        [DisplayName("Product Id")]
        public int ProductId { get; set; }

        [DisplayName("Location Id")]
        public int LocationId { get; set; }

        [DisplayName("Stock")]
        public int InventoryAmount { get; set; }
    }
}
