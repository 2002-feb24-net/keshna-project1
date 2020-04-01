using CupCakeData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CupCakeData
{
     /// <summary>
    /// A repository managing data access for Customer,Location and Order objects 
    /// using Entity Framework.
    /// </summary>
    /// <remarks>
    /// This class ought to have better exception handling and logging.
    /// </remarks>
        public class OrdersByLocationDB
        {
            public void GetOrdersByLocationDB(int locationID)
            {

                 DbContextOptions<CupCakeShopContext> options = new DbContextOptionsBuilder<CupCakeShopContext>()
                         .UseSqlServer(secret.ConnectionString).Options;
                 var context = new CupCakeShopContext(options);
                 var context2 = new CupCakeShopContext(options);
                 var context3 = new CupCakeShopContext(options);

                int count = 0;

                foreach (Orders order in context.Orders)
                {
                    var product = context2.Product.FirstOrDefault(p => p.ProductId == order.ProductId);
                    var location = context3.Location.FirstOrDefault(p => p.LocationId == order.LocationId);

                    if (order.LocationId == locationID)
                    {
                        Console.WriteLine("------------------------------------------------------------------------------------------");
                        Console.WriteLine($"| LocationID: {order.LocationId} | Location: {location.City} | Product: {product.Pname} | Quantity: {order.Quantity} | Date: {order.OrderTime} |");
                        Console.WriteLine("------------------------------------------------------------------------------------------");
                    
                    }
                else
                {
                    Console.WriteLine("--No data--");
                }
            }
                if (count == 0)
                {
                    Console.WriteLine("\nPress a key to continue");
                    Console.ReadKey();
                }
            }
        }
    
}
