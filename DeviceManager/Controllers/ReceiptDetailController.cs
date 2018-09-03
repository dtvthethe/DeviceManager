using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeviceManager.Models;

namespace DeviceManager.Controllers
{
    public class ReceiptDetailController : Controller
    {
        private DeviceManagerDBEntities db = new DeviceManagerDBEntities();

        // GET: ReceiptDetails
        public ActionResult Index()
        {
            var receiptDetails = db.ReceiptDetails.Include(r => r.Device).Include(r => r.Receipt);
            return View(receiptDetails.ToList());
        }

        // GET: ReceiptDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiptDetail receiptDetail = db.ReceiptDetails.Find(id);
            if (receiptDetail == null)
            {
                return HttpNotFound();
            }
            return View(receiptDetail);
        }

        // GET: ReceiptDetails/Create
        public PartialViewResult Create()
        {
            ViewBag.IDDevice = new SelectList(db.Devices, "ID", "Name");
            return PartialView();
        }

        // POST: ReceiptDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDReceipt,IDDevice,Quantity,CreatedBy,CreatedDate,UpdatedDate,Note,UpdatedBy")] ReceiptDetail receiptDetail)
        {
            if (ModelState.IsValid)
            {
                db.ReceiptDetails.Add(receiptDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDDevice = new SelectList(db.Devices, "ID", "Name", receiptDetail.IDDevice);
            ViewBag.IDReceipt = new SelectList(db.Receipts, "ID", "UsernameReceipt", receiptDetail.IDReceipt);
            return View(receiptDetail);
        }

        // GET: ReceiptDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiptDetail receiptDetail = db.ReceiptDetails.Find(id);
            if (receiptDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDDevice = new SelectList(db.Devices, "ID", "Name", receiptDetail.IDDevice);
            ViewBag.IDReceipt = new SelectList(db.Receipts, "ID", "UsernameReceipt", receiptDetail.IDReceipt);
            return View(receiptDetail);
        }

        // POST: ReceiptDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDReceipt,IDDevice,Quantity,CreatedBy,CreatedDate,UpdatedDate,Note,UpdatedBy")] ReceiptDetail receiptDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receiptDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDDevice = new SelectList(db.Devices, "ID", "Name", receiptDetail.IDDevice);
            ViewBag.IDReceipt = new SelectList(db.Receipts, "ID", "UsernameReceipt", receiptDetail.IDReceipt);
            return View(receiptDetail);
        }

        // GET: ReceiptDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiptDetail receiptDetail = db.ReceiptDetails.Find(id);
            if (receiptDetail == null)
            {
                return HttpNotFound();
            }
            return View(receiptDetail);
        }

        // POST: ReceiptDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReceiptDetail receiptDetail = db.ReceiptDetails.Find(id);
            db.ReceiptDetails.Remove(receiptDetail);
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
