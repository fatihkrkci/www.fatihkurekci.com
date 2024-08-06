using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyResumeWebsite.Models.Entity;

namespace MyResumeWebsite.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        MyResumeWebsiteEntities db = new MyResumeWebsiteEntities();

        public ActionResult Index()
        {
            var aboutMe = db.AboutMe.ToList();
            return View(aboutMe);
        }

        public PartialViewResult Experiences()
        {
            var experiences = db.Experiences.Where(x => x.Status == true).ToList();
            return PartialView(experiences);
        }

        public PartialViewResult Educations()
        {
            var educations = db.Educations.Where(x => x.Status == true).ToList();
            return PartialView(educations);
        }

        public PartialViewResult Skills()
        {
            var skills = db.Skills.Where(x => x.Status == true).ToList();
            return PartialView(skills);
        }

        public PartialViewResult Certificates()
        {
            var certificates = db.Certificates.Where(x => x.Status == true).ToList();
            return PartialView(certificates);
        }

        public PartialViewResult Projects()
        {
            var projects = db.Projects.Where(x => x.Status == true).ToList();
            return PartialView(projects);
        }

        [HttpGet]
        public PartialViewResult Contact()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Contact(Contact contact)
        {
            contact.Date = DateTime.Now;
            db.Contact.Add(contact);
            db.SaveChanges();
            return PartialView();
        }

        public PartialViewResult SocialMedia()
        {
            var socialMedias = db.SocialMedia.Where(x => x.Status == true).ToList();
            return PartialView(socialMedias);
        }
    }
}