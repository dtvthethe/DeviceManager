using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using AutoMapper;
using DeviceManager.Decorators;
using DeviceManager.Models;
using DeviceManager.Models.ViewModels;

namespace DeviceManager.Controllers
{
    [SessionAuthorize]
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
            receipt.UserList = new SelectList(db.Users, "Username", "FullName");
            receipt.Devices = new List<DeviceViewModel>();

            return View(receipt);
        }

        // POST: Receipt/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Create(ReceiptViewModel receipt)
        {
            var p = new Page();
            try
            {

                // Save Receipt:
                var rec = db.Receipts.Add(new Receipt
                {
                    UsernameReceipt = receipt.UsernameReceipt,
                    IDProvider = receipt.IDProvider,
                    Note = receipt.Note,
                    CreatedBy = "admin",
                    CreatedDate = DateTime.Now
                });
                db.SaveChanges();

                // Save Device:
                foreach (var item in receipt.Devices)
                {
                    db.Devices.Add(new Device()
                    {
                        CreatedBy = "admin",
                        CreatedDate = DateTime.Now,
                        Info = item.Info,
                        Name = item.Name,
                        Note = item.Note,
                        Price = item.Price,
                        Quantity = item.Quantity,
                        IDReceipt = rec.ID,
                        IDCategory = item.Category.ID,
                        IDStatus = item.Status.ID,
                        IDUnit = item.Unit.ID,
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

        // GET: Receipt/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var receipt = Mapper.Map<ReceiptViewModel>(db.Receipts.Find(id));
            if (receipt == null)
            {
                return HttpNotFound();
            }
            receipt.ProviderList = new SelectList(db.Providers, "ID", "Name");
            receipt.UserList = new SelectList(db.Users, "Username", "FullName");
            receipt.DeviceEdits = db.Devices.Select(_ => new DeviceEditViewModel()
            {
                ID = _.ID,
                Unit = new ViewModelBase()
                {
                    ID = _.Unit.ID,
                    Name = _.Unit.Name
                },
                Category = new ViewModelBase()
                {
                    ID = _.Category.ID,
                    Name = _.Category.Name
                },
                Status = new ViewModelBase()
                {
                    ID = _.Status.ID,
                    Name = _.Status.Name
                },
                IDReceipt = _.IDReceipt,
                Info = _.Info,
                Name = _.Name,
                Note = _.Note,
                Price = _.Price,
                Quantity = _.Quantity,
                IDUnit = _.IDUnit,
                Action = ActionEnum.NONE
            }).Where(_ => _.IDReceipt == id).ToList();

            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(receipt.DeviceEdits);
            ViewBag.json = json;

            return View(receipt);
        }

        // POST: Receipt/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Edit(ReceiptViewModel receipt)
        {
            var p = new Page();
            try
            {
                var rec = db.Receipts.Find(receipt.ID);
                rec.IDProvider = receipt.IDProvider;
                rec.Note = receipt.Note;
                rec.UsernameReceipt = receipt.UsernameReceipt;
                rec.UpdatedBy = "admin";
                rec.UpdatedDate = DateTime.Now;

                foreach (var item in receipt.DeviceEdits)
                {
                    switch (item.Action)
                    {
                        case ActionEnum.ADD:
                            var de = new Device()
                            {
                                CreatedBy = "admin",
                                CreatedDate = DateTime.Now,
                                IDCategory = item.IDCategory,
                                IDStatus = item.IDStatus,
                                IDUnit = item.IDUnit,
                                Info = item.Info,
                                Name = item.Name,
                                Note = item.Note,
                                Price = item.Price,
                                Quantity = item.Quantity,
                                IDReceipt = rec.ID
                            };
                            db.Devices.Add(de);
                            break;
                        case ActionEnum.EDIT:
                            var dev = db.Devices.Find(item.ID);
                            dev.IDCategory = item.Category.ID;
                            dev.IDStatus = item.Status.ID;
                            dev.IDUnit = item.Unit.ID;
                            dev.Info = item.Info;
                            dev.Name = item.Name;
                            dev.Note = item.Note;
                            dev.Price = item.Price;
                            dev.Quantity = item.Quantity;
                            dev.UpdatedBy = "admin";
                            dev.UpdatedDate = DateTime.Now;

                            break;
                        case ActionEnum.DELETE:
                            var devi = db.Devices.Find(item.ID);
                            db.Devices.Remove(devi);
                            break;
                        case ActionEnum.NONE:
                            break;
                        default:
                            break;
                    }
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
