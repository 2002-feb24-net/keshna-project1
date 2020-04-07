using DataAccess.Entities;
using BusinessLogic;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.Extensions.Logging;
using BusinessLogic.Interface;

namespace DataAccess.Repositories
{
    
    /// <summary>
    /// A repository managing data access for Store objects
    /// using Entity Framework.
    /// </summary>
    /// <remarks>
    /// This class ought to have better exception handling and logging.
    /// </remarks>
    public class CupCakeRepository  : ICupCakeRepository
    {
        private readonly CupCakeContext _dbContext;
        private readonly ILogger<CupCakeRepository> _logger;

        /// <summary>
        /// Initializes a new repository.
        /// </summary>
        /// <param name="dbContext">The data source</param>
        /// <param name="logger">The logger</param>
        public CupCakeRepository(CupCakeContext context, ILogger<CupCakeRepository> logger)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }

        /// <summary>
        /// Get all Stores with deferred execution,
      
        /// </summary>
        /// <returns>The collection of stores</returns>
        public List<CupCake> GetStores(List<CupCake> locations)
        {
            if (_dbContext.Stores.Any())
            {
                foreach (Stores store in _dbContext.Stores)
                {
                    CupCake b = new CupCake(store.LocationId, $"{store.City}, {store.State}");
                    locations.Add(b);
                }
            } else
            {
                Console.WriteLine("There are no stores open");
            }
            return locations;
        }

        public CupCake SelectStore(List<CupCake> stores, int id)
        {
            var q = stores.Select(b => b).Where(n => n.LocationId == id);
            return q.First();
        }

        public bool SearchForCustomer(Customer customer1)
        {
            if (_dbContext.Customers.Any(c => (c.FirstName == customer1.FirstName) && (c.LastName == customer1.LastName)))
            {
                return true;
            } else
            {
                return false;
            }
        }

        /// <summary>
        /// Add a customer
        /// </summary>
        /// <param name="customer1">The Store</param>
        public void AddNewCustomer(Customer customer1)
        {
            if (customer1.CustomerId != 0)
            {
                _logger.LogWarning("Customer to be added has an ID ({CustomerId}) already: ignoring.", customer1.CustomerId);
            }

            _logger.LogInformation("Adding customer");
            var customer = new Customers
            {
                FirstName = customer1.FirstName,
                LastName = customer1.LastName
            };

            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            customer1.CustomerId = customer.CustomerId;
        }

        /// <summary>
        /// Get products by name
        /// </summary>
        public Product GetProductByTitle(string search, CupCake b)
        {
            var sqlProduct = _dbContext.Products.First(p => p.Pname == search);
            var sqlInventory = _dbContext.Inventory.First(i => 
            (i.ProductId == sqlProduct.ProductId) && (b.LocationId == i.LocationId));
            Product product = new Product(sqlProduct.ProductId, sqlProduct.Pname,  
                sqlProduct.Price, sqlInventory.InventoryAmount);
            return product;
        }   

        public void AddProductToOrder(Order o, Product p)
        {
            var track = _dbContext.Inventory.Include(p => p.Product).Select(z => z).Where(l => (l.ProductId == p.ProductId));
            var product = new OrderDetails
            {
                OrderId = o.OrderId,
                InventoryId = track.First().InventoryId
            };

            _dbContext.OrderDetails.Add(product);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Get a customer by name.
        /// </summary>
        /// <returns>The collection of Customers</returns>
    
        public Customer GetCustomerByName(string firstname, string lastname)
        {
            var sqlCust = _dbContext.Customers.First(c => (c.FirstName == firstname) && (c.LastName == lastname));

            Customer product = new Customer(sqlCust.FirstName, sqlCust.LastName);
            return product;

             }

        public void MakeOrder(int customerId, int storeId, Order blogic)
        {
            var order = new Orders
            {
                CustomerId = customerId,
                LocationId = storeId,
                Date = blogic.OrderDate
            };

            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            blogic.OrderId = order.OrderId;
        }

        /// <summary>
        /// Get inventory details
        /// </summary>
        public List<Product> GetInventory(int storeId, List<Product> products)
        {
            if (_dbContext.Inventory.Any())
            {
                foreach (Inventory s in _dbContext.Inventory.Include(p => p.Product).Where(l => l.LocationId == storeId))
                {
                    Product p = new Product(s.Product.ProductId,s.Product.Pname, s.Product.Price ,s.InventoryAmount);
                    products.Add(p);
                }
            }
            else
            {
                Console.WriteLine("This store has gone out of business");
            }
            return products;
        }

        /// <summary>
        /// Delete the inventory data
        /// </summary>
        public void DeleteInventory(CupCake b, Product p)
        {
            _logger.LogInformation("Deleting product {ProductId}", p);

            _dbContext.Inventory.Remove(_dbContext.Inventory.
                First(i => (i.LocationId == b.LocationId) && (i.ProductId == p.ProductId)));
        }

        /// <summary>
        /// Edit the inventory data
        /// </summary>
         public void EditInventory(CupCake b, Product p)
        {
            _logger.LogInformation("Updating Product {ProductId}", p);

            var Inventory = _dbContext.Inventory.First(i => (i.LocationId == b.LocationId) && (i.ProductId == p.ProductId));

            Inventory.InventoryAmount = p.InventoryAmount;
            _dbContext.SaveChanges();
            p.ProductId = Inventory.ProductId;
        }

        public List<CustomerOrderHistory> GetCustomerOrderHistory(Customer custHistory)
        {
            List<CustomerOrderHistory> orders = new List<CustomerOrderHistory>();
            var query = from customerS in _dbContext.Customers
                        join order in _dbContext.Orders on customerS.CustomerId equals order.CustomerId
                        join orderD in _dbContext.OrderDetails on order.OrderId equals orderD.OrderId
                        join inv in _dbContext.Inventory on orderD.InventoryId equals inv.InventoryId
                        join prod in _dbContext.Products on inv.ProductId equals prod.ProductId
                        where customerS.FirstName == custHistory.FirstName && customerS.LastName == custHistory.LastName
                        select new { order.LocationId, customerS.FirstName, customerS.LastName, order.Date, prod.Pname, prod.Price };
            foreach (var item in query)
            {
                CustomerOrderHistory coh = new CustomerOrderHistory
                {
                    LocationID = item.LocationId,
                    Name = $"{item.FirstName} {item.LastName}",
                    Date = item.Date,
                    Pname = item.Pname,
                    Price = item.Price
                };
                orders.Add(coh);
            }
            return orders;
        }

        /// <summary>
        /// Get order history.
        /// </summary>
        /// <param name="id">The ID of the store location</param>
        public List<StoreOrderHistory> GetStoreOrderHistory(int id)
        {
            List<StoreOrderHistory> orders = new List<StoreOrderHistory>();
            var storeQuery = from store in _dbContext.Stores
                             join order in _dbContext.Orders on store.LocationId equals order.LocationId
                             join storeCust in _dbContext.Customers on order.CustomerId equals storeCust.CustomerId
                             join orderD in _dbContext.OrderDetails on order.OrderId equals orderD.OrderId
                             join inv in _dbContext.Inventory on orderD.InventoryId equals inv.InventoryId
                             join prod in _dbContext.Products on inv.ProductId equals prod.ProductId
                             where store.LocationId == id
                             select new { order.OrderId, store.City, store.State, storeCust.FirstName, storeCust.LastName, order.Date, prod.Pname, prod.Price, inv.InventoryAmount };
            foreach (var item in storeQuery)
            {
                StoreOrderHistory soh = new StoreOrderHistory
                {
                    OrderID = item.OrderId,
                    Name = $"{item.FirstName} {item.LastName}",
                    Date = item.Date,
                    Pname = item.Pname,
                    Price = item.Price,
                    InventoryAmount = item.InventoryAmount
                };
                orders.Add(soh);
            }
            return orders;
        }


    }
}
