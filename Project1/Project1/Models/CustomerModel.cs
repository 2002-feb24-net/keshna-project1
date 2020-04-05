using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Project1.Models
{
    public class CustomerModel
    {
        [Required]
        [DisplayName("ID")]
        public int CustomerID { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
    }
}
