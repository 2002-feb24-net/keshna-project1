using System.Collections.Generic;
using System.Linq;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using Project1.Models;

namespace Project1.Controllers
{
    public class OrderController : Controller
    {
        private readonly CupCakeRepository _repository;

        public OrderController(CupCakeRepository repository)
        {
            _repository = repository;
        }
        // GET: Order
        public ActionResult Index()
        {
            List<CupCake> locations = new List<CupCake>();
            _repository.GetStores(locations);

            var cupcakes = locations.Select(s => new StoreModel
            {
                Id = s.LocationId,
                Location = s.Location

            });
            return View(cupcakes);
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create(int id)
        {
            List<Product> products = new List<Product>();
            _repository.GetInventory(id, products);

            var inventory = products.Select(i => new ProductModel
            {
                ID = i.ProductId,
                Pname = i.Pname,
                Price = i.Price
            });
            TempData["storeID"] = id;
            return View(inventory);
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult PlaceOrder()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PlaceOrder(string id, CustomerModel cModel)
        {
            try
            {
                List<CupCake> location = new List<CupCake>();
                int storeID = int.Parse(TempData["storeID"].ToString());
                _repository.GetStores(location);
                CupCake choice = _repository.SelectStore(location, storeID);
                Customer c = new Customer(cModel.FirstName, cModel.LastName);
                if (!_repository.SearchForCustomer(c))
                {
                    _repository.AddNewCustomer(c);
                }
                else
                {
                    var retCust = _repository.GetCustomerByName(c.FirstName, c.LastName);
                    c.CustomerId = retCust.CustomerId;
                }
                Product p = _repository.GetProductByTitle(id, choice);
                Order o = new Order();
                _repository.MakeOrder(c.CustomerId, choice.LocationId, o);
                p.ReduceInventory();
                _repository.EditInventory(choice, p);
                _repository.AddProductToOrder(o, p);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}