using GeneralStore.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GeneralStore.MVC.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Customer
        public ActionResult Index()
        {
            List<Customer> customers = _db.Customers.ToList();
            List<Customer> orgCust = customers.OrderBy(c => c.LastName).ToList();
            return View(orgCust);
        }

        //GET Customer
        public ActionResult Create()
        {
            return View();
        }

        //POST: Customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _db.Customers.Add(customer);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(customer);
        }

        //GET Delete
        //Product/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = _db.Customers.Find(id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        //POST Delete
        //Product/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var customer =_db.Customers.Find(id);
            _db.Customers.Remove(customer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET Edit
        //Product/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = _db.Customers.Find(id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        //GET Edit
        //Product/Edit/{id}
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if(ModelState.IsValid)
            {
                _db.Entry(customer).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        //Get : Details
        //Product/Details/{id}
        public ActionResult Details (int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = _db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

    }
}