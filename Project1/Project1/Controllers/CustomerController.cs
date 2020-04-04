using System.Linq;
using BusinessLogic;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1.Models;

namespace Project1.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CupCakeRepository _repository;

        public CustomerController(CupCakeRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CustomerModel cModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(cModel);
                }
                TempData["fname"] = cModel.FirstName;
                TempData["lname"] = cModel.LastName;
                return RedirectToAction(nameof(Details));
            }
            catch
            {
                ModelState.AddModelError("Name", "Invalid Name");
                return View(cModel);
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: Customer/Details/5
        public ActionResult Details()
        {
            Customer c = new Customer(TempData["fname"].ToString(), TempData["lname"].ToString());
            var info = _repository.GetCustomerOrderHistory(c);
            var cOrders = info.Select(o => new CustomerOrderHistoryModel
            {
                LocationID = o.LocationID,
                Name = o.Name,
                Date = o.Date,
                Pname = o.Pname,
                Price = o.Price
            });
            return View(cOrders);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
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

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
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

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
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