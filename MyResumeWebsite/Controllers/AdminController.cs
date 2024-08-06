using MyResumeWebsite.Helpers;
using MyResumeWebsite.Models.Entity;
using MyResumeWebsite.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyResumeWebsite.Controllers
{
    public class AdminController : Controller
    {
        GenericRepository<Admin> repo = new GenericRepository<Admin>();
        public ActionResult Index()
        {
            var admins = repo.List();
            return View(admins);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Admin p)
        {
            p.Password = PasswordHelper.HashPassword(p.Password);
            repo.Add(p);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Admin t = repo.Find(x => x.ID == id);
            repo.Delete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetAdmin(int id)
        {
            Admin t = repo.Find(x => x.ID == id);
            return View((object)t);
        }

        [HttpPost]
        public ActionResult GetAdmin(Admin p)
        {
            Admin t = repo.Find(x => x.ID == p.ID);
            t.Username = p.Username;
            t.Password = PasswordHelper.HashPassword(p.Password); ;
            repo.Update(t);
            return RedirectToAction("Index");
        }

        public ActionResult Active(int id)
        {
            Admin t = repo.Find(x => x.ID == id);
            t.Status = true;
            repo.Update(t);
            return RedirectToAction("Index");
        }

        public ActionResult Passive(int id)
        {
            Admin t = repo.Find(x => x.ID == id);
            t.Status = false;
            repo.Update(t);
            return RedirectToAction("Index");
        }
    }
}