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
using DeviceManager.Models.ViewModels;
using AutoMapper;

namespace DeviceManager.Controllers
{
    public class DeviceController : Controller
    {
        private DeviceManagerDBEntities db = new DeviceManagerDBEntities();

        // GET: Device
        public async Task<ActionResult> Index()
        {
            var devices = db.Devices.Include(d => d.Category).Include(d => d.Status).Include(d => d.Unit);
            return View(await devices.ToListAsync());
        }

        // GET: Device/Details/5
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

        // GET: Device/Create
        public PartialViewResult Create()
        {
            ViewBag.IDCategory = new SelectList(db.Categories, "ID", "Name");
            ViewBag.IDStatus = new SelectList(db.Status, "ID", "Name");
            ViewBag.IDUnit = new SelectList(db.Units, "ID", "Name");
            return PartialView();
        }

        // POST: Device/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Create(DeviceViewModel device)
        {
            var deviceVM = Mapper.Map<DeviceEditViewModel>(device);
            deviceVM.Category = Mapper.Map<ViewModelBase>(db.Categories.Find(device.IDCategory));
            deviceVM.Unit = Mapper.Map<ViewModelBase>(db.Units.Find(device.IDUnit));
            deviceVM.Status = Mapper.Map<ViewModelBase>(db.Status.Find(device.IDStatus));

            return Json(deviceVM);
        }

        [HttpGet]
        public string GetUnitName(int id = 0) {
            if (id <= 0)
            {
                return "ERROR";
            }
            else {
                return db.Devices.Find(id).Unit.Name;
            }
        }

        [HttpPost]
        public PartialViewResult EditPartial(DeviceEditViewModel device)
        {
            ViewBag.DeviceIDUnit = new SelectList(db.Units, "ID", "Name", device.IDUnit);
            ViewBag.DeviceIDStatus = new SelectList(db.Status, "ID", "Name", device.IDStatus);
            ViewBag.DeviceIDCategory = new SelectList(db.Categories, "ID", "Name", device.IDCategory);

            return PartialView(device);
        }

        // GET: Device/Edit/5
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

        // POST: Device/Edit/5
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

        // GET: Device/Delete/5
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

        // POST: Device/Delete/5
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
