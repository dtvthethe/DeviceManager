using DeviceManager.Decorators;
using DeviceManager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeviceManager.Controllers
{
    [SessionAuthorize]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("User");
            return RedirectToAction("Index","Home");
        }

        [ChildActionOnly]
        public PartialViewResult UserInfo()
        {
            var user = (UserLogin)Session["User"];
            return PartialView(user);
        }
    }
}