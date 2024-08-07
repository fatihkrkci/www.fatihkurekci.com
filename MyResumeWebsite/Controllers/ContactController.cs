using MyResumeWebsite.Models.Entity;
using MyResumeWebsite.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyResumeWebsite.Controllers
{
    public class ContactController : Controller
    {
        GenericRepository<Contact> repo = new GenericRepository<Contact>();
        public ActionResult Index()
        {
            var messages = repo.List().OrderByDescending(x => x.Date).ToList();
            return View(messages);
        }

        [HttpGet]
        public ActionResult ReadAll(int id)
        {
            var contact = repo.Find(x => x.ID == id);
            return View(contact);
        }

        public ActionResult Delete(int id)
        {
            Contact t = repo.Find(x => x.ID == id);
            repo.Delete(t);
            return RedirectToAction("Index");
        }
    }
}