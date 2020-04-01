using System;
using System.Collections.Generic;
using System.Text;

namespace CupCakeLib.Models
{
  public class Menu
    {
        //it is supposed to be a menu of products i.e cupcakes
          public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public decimal Price { get; set; }
    }
}
