using System.ComponentModel.DataAnnotations;


namespace Project1.Models
{
    public class ProductModel
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Cup-Cake Name")]
        public string Pname { get; set; }

      
        [Required]
        public decimal Price { get; set; }

        public int StoreID { get; set; }


    }
}
