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
    public class DeliveryDetailController : Controller
    {
        private DeviceManagerDBEntities db = new DeviceManagerDBEntities();

        // GET: DeliveryDetail
        public async Task<ActionResult> Index()
        {
            var deliveryDetails = db.DeliveryDetails.Include(d => d.Delivery).Include(d => d.Device);
            return View(await deliveryDetails.ToListAsync());
        }

        // GET: DeliveryDetail/Details/5
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

        private DeliveryDetailViewModel InitialDeliveryDetail()
        {
            var deliveryDetailVM = new DeliveryDetailViewModel();
            deliveryDetailVM.DeviceList = new SelectList(db.Devices, "ID", "Name");

            return deliveryDetailVM;
        }

        // GET: DeliveryDetail/Create
        public PartialViewResult Create()
        {
            return PartialView(InitialDeliveryDetail());
        }

        // POST: DeliveryDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Create(DeliveryDetailEditViewModel deliveryDetail)
        {
            var page = new Page();
            page.Message = "Da nhan dc data";
            page.MessageLevel = MessageLevel.SUCCESS;
            deliveryDetail.Page = page;
            deliveryDetail.Device = db.Devices.Select(_ => new DeviceEditViewModel
            {
                ID = _.ID,
                Name = _.Name,
                UnitName = _.Unit.Name
            }).FirstOrDefault(_ => _.ID == deliveryDetail.IDDevice);
            deliveryDetail.Note = deliveryDetail.Note ?? "";

            return Json(deliveryDetail);
        }

        // GET: DeliveryDetail/Edit/5
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

        // POST: DeliveryDetail/Edit/5
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
            return View();
        }

        // GET: DeliveryDetail/Delete/5
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

        // POST: DeliveryDetail/Delete/5
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
