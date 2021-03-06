﻿using System.ComponentModel.DataAnnotations;


namespace Project1.Models
{
    public class ProductModel
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Cup-Cake Name")]
        public string Pname { get; set; }
      
        [Required]
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Store ID")]
        public int StoreID { get; set; }


    }
}
