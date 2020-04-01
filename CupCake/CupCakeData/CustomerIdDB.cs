using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CupCakeData.Entities;
using Microsoft.EntityFrameworkCore;

namespace CupCakeData
{
    /// <summary>
    /// A repository managing data access for Customer objects a
    /// using Entity Framework.
    /// </summary>
    /// <remarks>
    /// This class ought to have better exception handling and logging.
    /// </remarks>
    public class CustomerIdDB
    {
        public int GetCustomerIdDB(string firstName, string lastName)
        {

            DbContextOptions<CupCakeShopContext> options = new DbContextOptionsBuilder<CupCakeShopContext>()
                .UseSqlServer(secret.ConnectionString).Options;
            var context = new CupCakeShopContext(options);

            var foundName = context.Customer.FirstOrDefault(p => p.FirstName == firstName && p.LastName == lastName);   //find the first

            if (foundName is null)
            {
                Console.WriteLine("No Record Found");         // validate
                return 0;
            }
            else
                return foundName.CustomerId;
        }
    }
}
