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
using AutoMapper;
using DeviceManager.Models.ViewModels;
using System.Web.Script.Serialization;

namespace DeviceManager.Controllers
{
    public class DeliveryController : Controller
    {
        private DeviceManagerDBEntities db = new DeviceManagerDBEntities();

        // GET: Deliveries
        public async Task<ActionResult> Index()
        {
            var deliveries = db.Deliveries.Include(d => d.User).Include(d => d.User1);
            return View(await deliveries.ToListAsync());
        }

        // GET: Deliveries/Details/5
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

        // GET: Delivery/Create
        public ActionResult Create()
        {

            var deliveryVM = new DeliveryViewModel();
            deliveryVM.UserList = new SelectList(db.Users, "Username", "FullName");
            deliveryVM.DeliveryDetails = new List<DeliveryDetailViewModel>();

            return View(deliveryVM);

        }

        // POST: Deliveries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Create(DeliveryViewModel delivery)
        {
            var p = new Page();

            try
            {
                var deli = db.Deliveries.Add(new Delivery()
                {
                    CreatedBy = "admin",
                    CreatedDate = DateTime.Now,
                    Note = delivery.Note,
                    UsernameFromDelivery = delivery.UsernameFromDelivery,
                    UsernameToDelivery = delivery.UsernameToDelivery
                });
                db.SaveChanges();

                foreach (var item in delivery.DeliveryDetails)
                {
                    db.DeliveryDetails.Add(new DeliveryDetail()
                    {
                        CreatedBy = "admin",
                        CreatedDate = DateTime.Now,
                        DateExpires = Convert.ToDateTime(item.DateExpires),
                        IDDelivery = deli.ID,
                        IDDevice = item.IDDevice,
                        Note = item.Note,
                        Quantity = item.Quantity,
                    });
                }

                db.SaveChanges();

                p.Message = "Lưu thành công";
                p.MessageLevel = MessageLevel.SUCCESS;

                return Json(p);
            }
            catch (Exception ex)
            {
                p.Message = "Lưu thất bại: " + ex.Message;
                p.MessageLevel = MessageLevel.ERROR;

                return Json(p);
            }
        }

        // GET: Deliveries/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var deliveryVM = db.Deliveries.Select(_ => new DeliveryViewModel
            {
                ID = _.ID,
                Note = _.Note,
                UsernameFromDelivery = _.UsernameFromDelivery,
                UsernameToDelivery = _.UsernameToDelivery
            }).FirstOrDefault(_ => _.ID == id);

            if (deliveryVM == null) {
                return HttpNotFound();
            }

            deliveryVM.UserList = new SelectList(db.Users, "Username", "FullName");
            deliveryVM.DeliveryDetailEdits = db.DeliveryDetails.Select(_ => new DeliveryDetailEditViewModel()
            {
                ID = _.ID,
                DateExpires = _.DateExpires.ToString(),
                Device = new DeviceEditViewModel()
                {
                    ID = _.Device.ID,
                    Name = _.Device.Name,
                    UnitName = _.Device.Unit.Name,
                },
                IDDelivery = _.IDDelivery,
                IDDevice = _.IDDevice,
                Note = _.Note,
                Quantity = _.Quantity,
                Action = ActionEnum.NONE
            }).Where(_ => _.IDDelivery == id).ToList();



            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(deliveryVM.DeliveryDetailEdits);
            ViewBag.json = json;
            return View(deliveryVM);
        }

        // POST: Deliveries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult> Edit(DeliveryViewModel delivery)
        {
            var aa = delivery;
            var aaa = aa;
            return View(delivery);
        }

        // GET: Deliveries/Delete/5
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

        // POST: Deliveries/Delete/5
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
