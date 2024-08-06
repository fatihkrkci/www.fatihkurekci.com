using MyResumeWebsite.Helpers;
using MyResumeWebsite.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyResumeWebsite.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            MyResumeWebsiteEntities db = new MyResumeWebsiteEntities();
            string hashedPassword = PasswordHelper.HashPassword(p.Password);
            ViewBag.hashedPassword = hashedPassword;
            var userInfo = db.Admin.FirstOrDefault(x => x.Username == p.Username && x.Password == hashedPassword);
            if (userInfo != null)
            {
                FormsAuthentication.SetAuthCookie(userInfo.Username, false);
                Session["Username"] = userInfo.Username.ToString();
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}