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
    public class DevicesController : Controller
    {
        private DeviceManagerDBEntities db = new DeviceManagerDBEntities();

        // GET: Admin/Devices
        public async Task<ActionResult> Index()
        {
            var devices = db.Devices.Include(d => d.Category).Include(d => d.Status).Include(d => d.Unit);
            return View(await devices.ToListAsync());
        }

        // GET: Admin/Devices/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Device device = await db.Devices.FindAsync(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            return View(device);
        }

        // GET: Admin/Devices/Create
        public ActionResult Create()
        {
            ViewBag.IDCategory = new SelectList(db.Categories, "ID", "Name");
            ViewBag.IDStatus = new SelectList(db.Status, "ID", "Name");
            ViewBag.IDUnit = new SelectList(db.Units, "ID", "Name");
            return View();
        }

        // POST: Admin/Devices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Quantity,IDCategory,IDUnit,IDStatus,Price,Info,CreatedBy,CreatedDate,UpdatedDate,Note,UpdatedBy")] Device device)
        {
            if (ModelState.IsValid)
            {
                db.Devices.Add(device);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDCategory = new SelectList(db.Categories, "ID", "Name", device.IDCategory);
            ViewBag.IDStatus = new SelectList(db.Status, "ID", "Name", device.IDStatus);
            ViewBag.IDUnit = new SelectList(db.Units, "ID", "Name", device.IDUnit);
            return View(device);
        }

        // GET: Admin/Devices/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Device device = await db.Devices.FindAsync(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCategory = new SelectList(db.Categories, "ID", "Name", device.IDCategory);
            ViewBag.IDStatus = new SelectList(db.Status, "ID", "Name", device.IDStatus);
            ViewBag.IDUnit = new SelectList(db.Units, "ID", "Name", device.IDUnit);
            return View(device);
        }

        // POST: Admin/Devices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Quantity,IDCategory,IDUnit,IDStatus,Price,Info,CreatedBy,CreatedDate,UpdatedDate,Note,UpdatedBy")] Device device)
        {
            if (ModelState.IsValid)
            {
                db.Entry(device).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDCategory = new SelectList(db.Categories, "ID", "Name", device.IDCategory);
            ViewBag.IDStatus = new SelectList(db.Status, "ID", "Name", device.IDStatus);
            ViewBag.IDUnit = new SelectList(db.Units, "ID", "Name", device.IDUnit);
            return View(device);
        }

        // GET: Admin/Devices/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Device device = await db.Devices.FindAsync(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            return View(device);
        }

        // POST: Admin/Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Device device = await db.Devices.FindAsync(id);
            db.Devices.Remove(device);
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
