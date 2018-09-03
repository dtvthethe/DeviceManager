using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeviceManager.Models;
using DeviceManager.Models.ViewModels;

namespace DeviceManager.Controllers
{
    public class ReceiptController : Controller
    {
        private DeviceManagerDBEntities db = new DeviceManagerDBEntities();

        // GET: Receipt
        public ActionResult Index()
        {
            var receipts = db.Receipts.Include(r => r.Provider).Include(r => r.User);
            return View(receipts.ToList());
        }

        // GET: Receipt/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = db.Receipts.Find(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            return View(receipt);
        }

        // GET: Receipt/Create
        public ActionResult Create()
        {
            var receipt = new ReceiptViewModel();
            receipt.ProviderList = new SelectList(db.Providers, "ID", "Name");
            receipt.UserList = new SelectList(db.Users, "Username", "Username");
            receipt.ReceiptDetails = new List<ReceiptDetailViewModel>();

            return View(receipt);
        }

        // POST: Receipt/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UsernameReceipt,IDProvider,CreatedBy,CreatedDate,UpdatedDate,Note,UpdatedBy")] Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                db.Receipts.Add(receipt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDProvider = new SelectList(db.Providers, "ID", "Name", receipt.IDProvider);
            ViewBag.UsernameReceipt = new SelectList(db.Users, "Username", "Password", receipt.UsernameReceipt);
            return View(receipt);
        }

        // GET: Receipt/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = db.Receipts.Find(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDProvider = new SelectList(db.Providers, "ID", "Name", receipt.IDProvider);
            ViewBag.UsernameReceipt = new SelectList(db.Users, "Username", "Password", receipt.UsernameReceipt);
            return View(receipt);
        }

        // POST: Receipt/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UsernameReceipt,IDProvider,CreatedBy,CreatedDate,UpdatedDate,Note,UpdatedBy")] Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receipt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDProvider = new SelectList(db.Providers, "ID", "Name", receipt.IDProvider);
            ViewBag.UsernameReceipt = new SelectList(db.Users, "Username", "Password", receipt.UsernameReceipt);
            return View(receipt);
        }

        // GET: Receipt/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = db.Receipts.Find(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            return View(receipt);
        }

        // POST: Receipt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Receipt receipt = db.Receipts.Find(id);
            db.Receipts.Remove(receipt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
