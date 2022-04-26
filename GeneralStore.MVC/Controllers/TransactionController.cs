using GeneralStore.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeneralStore.MVC.Controllers
{
    public class TransactionController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Transaction
        public ActionResult Index()
        {
            List<Transaction> tList = _db.Transactions.ToList();
            List<Transaction> oTList = tList.OrderBy(t => t.DateOfTransaction).ToList();
            return View(oTList);
        }

        //GET: Create
        // Transaction/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(_db.Products, "ProductId", "Name");
            ViewBag.CustomerId = new SelectList(_db.Customers, "CustomerId", "FullName");
            return View();
        }

        //POST: Create
        //Transaction/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Transaction transaction)
        {
            ViewBag.ProductId = new SelectList(_db.Products, "ProductId", "Name");
            ViewBag.CustomerId = new SelectList(_db.Customers, "CustomerId", "FullName");
            if (ModelState.IsValid)
            {
                _db.Transactions.Add(transaction);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transaction);
        }

        //Get: Delete
        //Transaction/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            var transaction = _db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        //POST: Delete
        //Transaction/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var transaction = _db.Transactions.Find(id);

            _db.Transactions.Remove(transaction);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Get: Edit
        //Transaction/Edit/{id}
        public ActionResult Edit(int? id)
        {
            ViewBag.ProductId = new SelectList(_db.Products, "ProductId", "Name");
            ViewBag.CustomerId = new SelectList(_db.Customers, "CustomerId", "FullName");
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var transaction = _db.Transactions.Find(id);
            if(transaction==null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        //Post: Edit
        //Transaction/Edit/{id}
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Transaction transaction)
        {
            ViewBag.ProductId = new SelectList(_db.Products, "ProductId", "Name");
            ViewBag.CustomerId = new SelectList(_db.Customers, "CustomerId", "FullName");
            if (ModelState.IsValid)
            {
                _db.Entry(transaction).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transaction);
        }
        //Get: Detail
        //Transaction/Details/{id}
        public ActionResult Details (int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            var transaction = _db.Transactions.Find(id);
            if(transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

    }
}