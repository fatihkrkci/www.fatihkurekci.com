using MyResumeWebsite.Models.Entity;
using MyResumeWebsite.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyResumeWebsite.Controllers
{
    public class SocialMediaController : Controller
    {
        GenericRepository<SocialMedia> repo = new GenericRepository<SocialMedia>();
        public ActionResult Index()
        {
            var socialMedias = repo.List();
            return View(socialMedias);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(SocialMedia p)
        {
            repo.Add(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetSocialMedia(int id)
        {
            var socialMedia = repo.Find(x => x.ID == id);
            return View(socialMedia);
        }

        [HttpPost]
        public ActionResult GetSocialMedia(SocialMedia p)
        {
            var socialMedia = repo.Find(x => x.ID == p.ID);
            socialMedia.PlatformName = p.PlatformName;
            socialMedia.Link = p.Link;
            socialMedia.Icon = p.Icon;
            repo.Update(socialMedia);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var socialMedia = repo.Find(x => x.ID == id);
            socialMedia.Status = false;
            repo.Update(socialMedia);
            return RedirectToAction("Index");
        }

        public ActionResult Active(int id)
        {
            SocialMedia t = repo.Find(x => x.ID == id);
            t.Status = true;
            repo.Update(t);
            return RedirectToAction("Index");
        }

        public ActionResult Passive(int id)
        {
            SocialMedia t = repo.Find(x => x.ID == id);
            t.Status = false;
            repo.Update(t);
            return RedirectToAction("Index");
        }
    }
}