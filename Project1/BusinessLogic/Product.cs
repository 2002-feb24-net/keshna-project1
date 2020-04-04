using System;


namespace BusinessLogic
{
    public class Product
    {
        private int _InventoryAmount;

        public int InventoryAmount
        {
            get => _InventoryAmount;
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("The inventory amount can't be set to zero", nameof(value));
                }
                else if (value < 0)
                {
                    throw new ArgumentException("The inventory amount can't be set to a negative number\n", nameof(value));
                }
                _InventoryAmount = value;
            }
        }

        private string _Pname;

        public string Pname
        {
            get => _Pname;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("You forgot to enter the Pname.", nameof(value));
                }
                _Pname = value;
            }
        }

        public decimal Price { get; set; }


        public int ProductId { get; set; }

        public Product(int id, string Pname, decimal price, int count)
        {
            this.ProductId = id;
            this.Pname = Pname;
            this.Price = price;
            this.InventoryAmount = count;
        }

        public void ReduceInventory ()
        {
            if (this.InventoryAmount > 0)
            {
                this.InventoryAmount--;
            }
            else
            {
                Console.WriteLine("That item is out of stock");
            }
        }
    }
}
