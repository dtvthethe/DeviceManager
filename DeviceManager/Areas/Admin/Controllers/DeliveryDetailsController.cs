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
    public class DeliveryDetailsController : Controller
    {
        private DeviceManagerDBEntities db = new DeviceManagerDBEntities();

        // GET: Admin/DeliveryDetails
        public async Task<ActionResult> Index()
        {
            var deliveryDetails = db.DeliveryDetails.Include(d => d.Delivery).Include(d => d.Device);
            return View(await deliveryDetails.ToListAsync());
        }

        // GET: Admin/DeliveryDetails/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryDetail deliveryDetail = await db.DeliveryDetails.FindAsync(id);
            if (deliveryDetail == null)
            {
                return HttpNotFound();
            }
            return View(deliveryDetail);
        }

        // GET: Admin/DeliveryDetails/Create
        public ActionResult Create()
        {
            ViewBag.IDDelivery = new SelectList(db.Deliveries, "ID", "UsernameFromDelivery");
            ViewBag.IDDevice = new SelectList(db.Devices, "ID", "Name");
            return View();
        }

        // POST: Admin/DeliveryDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,IDDevice,IDDelivery,Quantity,DateExpires,CreatedBy,CreatedDate,UpdatedDate,Note,UpdatedBy")] DeliveryDetail deliveryDetail)
        {
            if (ModelState.IsValid)
            {
                db.DeliveryDetails.Add(deliveryDetail);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDDelivery = new SelectList(db.Deliveries, "ID", "UsernameFromDelivery", deliveryDetail.IDDelivery);
            ViewBag.IDDevice = new SelectList(db.Devices, "ID", "Name", deliveryDetail.IDDevice);
            return View(deliveryDetail);
        }

        // GET: Admin/DeliveryDetails/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryDetail deliveryDetail = await db.DeliveryDetails.FindAsync(id);
            if (deliveryDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDDelivery = new SelectList(db.Deliveries, "ID", "UsernameFromDelivery", deliveryDetail.IDDelivery);
            ViewBag.IDDevice = new SelectList(db.Devices, "ID", "Name", deliveryDetail.IDDevice);
            return View(deliveryDetail);
        }

        // POST: Admin/DeliveryDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,IDDevice,IDDelivery,Quantity,DateExpires,CreatedBy,CreatedDate,UpdatedDate,Note,UpdatedBy")] DeliveryDetail deliveryDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryDetail).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDDelivery = new SelectList(db.Deliveries, "ID", "UsernameFromDelivery", deliveryDetail.IDDelivery);
            ViewBag.IDDevice = new SelectList(db.Devices, "ID", "Name", deliveryDetail.IDDevice);
            return View(deliveryDetail);
        }

        // GET: Admin/DeliveryDetails/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryDetail deliveryDetail = await db.DeliveryDetails.FindAsync(id);
            if (deliveryDetail == null)
            {
                return HttpNotFound();
            }
            return View(deliveryDetail);
        }

        // POST: Admin/DeliveryDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DeliveryDetail deliveryDetail = await db.DeliveryDetails.FindAsync(id);
            db.DeliveryDetails.Remove(deliveryDetail);
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
