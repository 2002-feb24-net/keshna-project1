using System;

namespace BusinessLogic
{
    public class Customer
    {
        private string _FirstName;
        private string _LastName;

        public string FirstName
        {
            get => _FirstName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("You forgot to enter the customer's first name", nameof(value));
                }
                else if (value.Length > 20)
                {
                    throw new ArgumentException("That first name exceeds the 25 character limit\n Please try again.\n", nameof(value));
                }
                _FirstName = value;
            } 
        }

        public string LastName 
        {
            get => _LastName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("You forgot to enter the customer's last name", nameof(value));
                }
                else if (value.Length > 20)
                {
                    throw new ArgumentException("That last name exceeds the 25 character limit\n Please try again.\n", nameof(value));
                }
                _LastName = value;
            }
        }

        public int CustomerId { get; set; }

        public Order order { get; set; }


        public Customer(string FName, string LName)
        {
            this.FirstName = FName;
            this.LastName = LName;
        }
    }
}
