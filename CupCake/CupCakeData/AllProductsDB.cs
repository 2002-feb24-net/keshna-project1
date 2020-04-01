using System;
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
    public class AllProductsDB
    {
        public void GetAllProducts()
        {
            
            DbContextOptions<CupCakeShopContext> options = new DbContextOptionsBuilder<CupCakeShopContext>()
                .UseSqlServer(secret.ConnectionString).Options;
             var context = new CupCakeShopContext(options);
            foreach (Product product in context.Product)                     //display all
            {
                
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine($"| ProductId: {product.ProductId} | ProductName: {product.Pname} | Price  {product.Price} $");
                Console.WriteLine("-------------------------------------------");
            }
        }
    }
}
