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
    public class DeliveriesController : Controller
    {
        private DeviceManagerDBEntities db = new DeviceManagerDBEntities();

        // GET: Admin/Deliveries
        public async Task<ActionResult> Index()
        {
            var deliveries = db.Deliveries.Include(d => d.User).Include(d => d.User1);
            return View(await deliveries.ToListAsync());
        }

        // GET: Admin/Deliveries/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery delivery = await db.Deliveries.FindAsync(id);
            if (delivery == null)
            {
                return HttpNotFound();
            }
            return View(delivery);
        }

        // GET: Admin/Deliveries/Create
        public ActionResult Create()
        {
            ViewBag.UsernameFromDelivery = new SelectList(db.Users, "Username", "Password");
            ViewBag.UsernameToDelivery = new SelectList(db.Users, "Username", "Password");
            return View();
        }

        // POST: Admin/Deliveries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,UsernameFromDelivery,UsernameToDelivery,CreatedBy,CreatedDate,UpdatedDate,Note,UpdatedBy")] Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                db.Deliveries.Add(delivery);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UsernameFromDelivery = new SelectList(db.Users, "Username", "Password", delivery.UsernameFromDelivery);
            ViewBag.UsernameToDelivery = new SelectList(db.Users, "Username", "Password", delivery.UsernameToDelivery);
            return View(delivery);
        }

        // GET: Admin/Deliveries/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery delivery = await db.Deliveries.FindAsync(id);
            if (delivery == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsernameFromDelivery = new SelectList(db.Users, "Username", "Password", delivery.UsernameFromDelivery);
            ViewBag.UsernameToDelivery = new SelectList(db.Users, "Username", "Password", delivery.UsernameToDelivery);
            return View(delivery);
        }

        // POST: Admin/Deliveries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,UsernameFromDelivery,UsernameToDelivery,CreatedBy,CreatedDate,UpdatedDate,Note,UpdatedBy")] Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(delivery).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UsernameFromDelivery = new SelectList(db.Users, "Username", "Password", delivery.UsernameFromDelivery);
            ViewBag.UsernameToDelivery = new SelectList(db.Users, "Username", "Password", delivery.UsernameToDelivery);
            return View(delivery);
        }

        // GET: Admin/Deliveries/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery delivery = await db.Deliveries.FindAsync(id);
            if (delivery == null)
            {
                return HttpNotFound();
            }
            return View(delivery);
        }

        // POST: Admin/Deliveries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Delivery delivery = await db.Deliveries.FindAsync(id);
            db.Deliveries.Remove(delivery);
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
