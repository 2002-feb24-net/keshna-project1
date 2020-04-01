using CupCakeData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


namespace CupCakeData
{
     /// <summary>
    /// A repository managing data access for Customer
    /// using Entity Framework.
    /// </summary>
    /// <remarks>
    /// This class ought to have better exception handling and logging.
    /// </remarks>
    public class SearchCustomerDB
    {
        public void SearchForCustomerDB(string firstName, string lastName)
        {
            DbContextOptions<CupCakeShopContext> options = new DbContextOptionsBuilder<CupCakeShopContext>()
                .UseSqlServer(secret.ConnectionString).Options;
           var context = new CupCakeShopContext(options);
         

            var foundName = context.Customer.FirstOrDefault(p => p.FirstName == firstName && p.LastName == lastName);

            if (foundName is null)
            {
                Console.WriteLine("No Record Found");       //validation
                return;
            }
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"\n| CustomerId: {foundName.CustomerId} | CustomerName: {foundName.FirstName} {foundName.LastName} |");
            Console.WriteLine("-------------------------------------------");
        }
    }
}