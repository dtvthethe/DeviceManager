using DeviceManager.Decorators;
using DeviceManager.Models;
using DeviceManager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeviceManager.Controllers
{
    public class HomeController : Controller
    {

        private DeviceManagerDBEntities db = new DeviceManagerDBEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AccountLoginViewModel account)
        {
            var p = new Page();
            if (ModelState.IsValid)
            {
                var user = db.Users.Include("Role").FirstOrDefault(_ => _.Username == account.Username && _.Password == account.Password);

                if (user != null)
                {

                    Session["User"] = new UserLogin()
                    {
                        Email = user.Email,
                        FullName = user.FullName,
                        IDRole = user.IDRole,
                        Role = user.Role,
                        Username = user.Username
                    };
                    return RedirectToAction("Index", "Delivery");
                }
                else
                {
                    p.Message = "Sai tài khoản hoặc mật khẩu";
                    p.MessageLevel = MessageLevel.ERROR;
                }

                return View("Index");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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