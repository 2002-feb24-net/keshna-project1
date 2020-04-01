using System;
using Microsoft.EntityFrameworkCore;
//using NLog;
using CupCakeData.Entities;
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
    public class OrdersByCustomerDB
    {
        public void GetOrdersByCustomerDB(int customerID)
        {
           

            DbContextOptions<CupCakeShopContext> options = new DbContextOptionsBuilder<CupCakeShopContext>()
                .UseSqlServer(secret.ConnectionString).Options;
             var context = new CupCakeShopContext(options);
             var context2 = new CupCakeShopContext(options);      //3 context for 1.Cust 2.Prod 3.Loctn
             var context3 = new CupCakeShopContext(options);

            foreach (Orders order in context.Orders)
            {
                var product = context2.Product.FirstOrDefault(p => p.ProductId == order.ProductId);
                var location = context3.Location.FirstOrDefault(p => p.LocationId == order.LocationId);

              
                if (order.CustomerId == customerID)
                {
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                    Console.WriteLine($"| CustomerId: {order.CustomerId} | Location: {location.City} | ProductName: {product.Pname} | Quantity: {order.Quantity} | Date: {order.OrderTime} |" );
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("--No data--");
                }
            }
        }
    }
}
