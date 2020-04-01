using System;
using Microsoft.EntityFrameworkCore;
//using NLog;
using CupCakeData.Entities;


namespace CupCakeData
{
    /// <summary>
    /// A repository managing data access for Customer objects a
    /// using Entity Framework.
    /// </summary>
    /// <remarks>
    /// This class ought to have better exception handling and logging.
    /// </remarks>
    public class AddCustomerDB 

    {
        public void AddNewCustomerDB()
        {
            DbContextOptions<CupCakeShopContext> options = new DbContextOptionsBuilder<CupCakeShopContext>()
                .UseSqlServer(secret.ConnectionString).Options;
            var context = new CupCakeShopContext(options);

            Customer newCustomer = new Customer();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Cup Cake Shop\n");
                Console.WriteLine("Enter Customer First and Last Name:");
                Console.WriteLine("(or 1 to Return to Menu)\n");

                string customerName = Console.ReadLine();

                string[] fullName = customerName.Split(' ');

                if (fullName[0].ToLower() == "1")           //main menu
                {
                    return;
                }
                else if (string.IsNullOrEmpty(customerName) || fullName.Length != 2)    //validation
                {
                    Console.WriteLine("Invalid Name\n");
                    Console.WriteLine("Press a key to continue.");
                    Console.ReadKey();
                }
                else
                {
                    newCustomer.FirstName = fullName[0];            //add
                    newCustomer.LastName = fullName[1];
                    break;
                }
            }

            context.Customer.Add(newCustomer);

            context.SaveChanges();

            Console.Clear();
            Console.WriteLine("Cup Cake Shop\n");

            Console.WriteLine($"{newCustomer.FirstName} {newCustomer.LastName} added to the system.\n");   //show output
            Console.WriteLine("Press a key to continue: ");
            Console.ReadKey();
        }
    }

}
