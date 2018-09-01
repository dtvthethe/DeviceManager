using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeviceManager.Models;

namespace DeviceManager.Areas.Admin.Controllers
{
    public class ReceiptDetailsController : Controller
    {
        private DeviceManagerDBEntities db = new DeviceManagerDBEntities();

        // GET: Admin/ReceiptDetails
        public async Task<ActionResult> Index()
        {
            var receiptDetails = db.ReceiptDetails.Include(r => r.Device).Include(r => r.Receipt);
            return View(await receiptDetails.ToListAsync());
        }

        // GET: Admin/ReceiptDetails/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiptDetail receiptDetail = await db.ReceiptDetails.FindAsync(id);
            if (receiptDetail == null)
            {
                return HttpNotFound();
            }
            return View(receiptDetail);
        }

        // GET: Admin/ReceiptDetails/Create
        public ActionResult Create()
        {
            ViewBag.IDDevice = new SelectList(db.Devices, "ID", "Name");
            ViewBag.IDReceipt = new SelectList(db.Receipts, "ID", "UsernameReceipt");
            return View();
        }

        // POST: Admin/ReceiptDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,IDReceipt,IDDevice,Quantity,CreatedBy,CreatedDate,UpdatedDate,Note,UpdatedBy")] ReceiptDetail receiptDetail)
        {
            if (ModelState.IsValid)
            {
                db.ReceiptDetails.Add(receiptDetail);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDDevice = new SelectList(db.Devices, "ID", "Name", receiptDetail.IDDevice);
            ViewBag.IDReceipt = new SelectList(db.Receipts, "ID", "UsernameReceipt", receiptDetail.IDReceipt);
            return View(receiptDetail);
        }

        // GET: Admin/ReceiptDetails/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiptDetail receiptDetail = await db.ReceiptDetails.FindAsync(id);
            if (receiptDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDDevice = new SelectList(db.Devices, "ID", "Name", receiptDetail.IDDevice);
            ViewBag.IDReceipt = new SelectList(db.Receipts, "ID", "UsernameReceipt", receiptDetail.IDReceipt);
            return View(receiptDetail);
        }

        // POST: Admin/ReceiptDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,IDReceipt,IDDevice,Quantity,CreatedBy,CreatedDate,UpdatedDate,Note,UpdatedBy")] ReceiptDetail receiptDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receiptDetail).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDDevice = new SelectList(db.Devices, "ID", "Name", receiptDetail.IDDevice);
            ViewBag.IDReceipt = new SelectList(db.Receipts, "ID", "UsernameReceipt", receiptDetail.IDReceipt);
            return View(receiptDetail);
        }

        // GET: Admin/ReceiptDetails/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiptDetail receiptDetail = await db.ReceiptDetails.FindAsync(id);
            if (receiptDetail == null)
            {
                return HttpNotFound();
            }
            return View(receiptDetail);
        }

        // POST: Admin/ReceiptDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ReceiptDetail receiptDetail = await db.ReceiptDetails.FindAsync(id);
            db.ReceiptDetails.Remove(receiptDetail);
            await db.SaveChangesAsync();
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
