using MyResumeWebsite.Models.Entity;
using MyResumeWebsite.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyResumeWebsite.Controllers
{
    public class AboutMeController : Controller
    {
        GenericRepository<AboutMe> repo = new GenericRepository<AboutMe>();

        // GET: AboutMe
        [HttpGet]
        public ActionResult Index()
        {
            var aboutMe = repo.List();
            return View(aboutMe);
        }

        [HttpPost]
        public ActionResult Index(AboutMe p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Name = p.Name;
            t.Surname = p.Surname;
            t.Title = p.Title;
            t.Phone = p.Phone;
            t.Email = p.Email;
            t.Address = p.Address;
            t.TitleOfDescription = p.TitleOfDescription;
            t.Description = p.Description;
            t.Picture = p.Picture;
            repo.Update(t);
            return RedirectToAction("Index");
        }
    }
}