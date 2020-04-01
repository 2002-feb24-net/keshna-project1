using CupCakeData.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CupCakeData
{
    /// <summary>
    /// A repository managing data access for Location objects
    /// using Entity Framework.
    /// </summary>
    /// <remarks>
    /// This class ought to have better exception handling and logging.
    /// </remarks>
    public class AllLocationsDB
    {
        public void GetAllLocationsDB()
        {
            

            DbContextOptions<CupCakeShopContext> options = new DbContextOptionsBuilder<CupCakeShopContext>()
                .UseSqlServer(secret.ConnectionString).Options;
             var context = new CupCakeShopContext(options);

            foreach (Location location in context.Location)     //Just display all
            {
                
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine($"| LocationId: {location.LocationId} | City: {location.City} |");
                Console.WriteLine("----------------------------------------------");
            }
        }
    }
}
