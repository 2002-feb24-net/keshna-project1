using System.Collections.Generic;
using System.Linq;
using BusinessLogic;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1.Models;

namespace Project1.Controllers
{
    public class StoreController : Controller
    {
        private readonly CupCakeRepository _repository;

        public StoreController(CupCakeRepository repository)
        {
            _repository = repository;
        }
        // GET: Store
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

        // GET: Store/Details/5
        public ActionResult Details(int id)
        {
            var info = _repository.GetStoreOrderHistory(id);
            var sOrders = info.Select(o => new StoreOrderHistoryModel
            {
                OrderID = o.OrderID,
                Name = o.Name,
                Date = o.Date,
                Pname = o.Pname,
                Price = o.Price,
                InventoryAmount = o.InventoryAmount
            });
            return View(sOrders);
        }

        // GET: Store/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Store/Create
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

        // GET: Store/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Store/Edit/5
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

        // GET: Store/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Store/Delete/5
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