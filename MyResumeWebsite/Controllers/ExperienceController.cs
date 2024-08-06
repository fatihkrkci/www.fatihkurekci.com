using MyResumeWebsite.Models.Entity;
using MyResumeWebsite.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyResumeWebsite.Controllers
{
    public class ExperienceController : Controller
    {
        ExperienceRepository experienceRepository = new ExperienceRepository();

        public ActionResult Index()
        {
            var experiences = experienceRepository.List();
            return View(experiences);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Experiences p)
        {
            experienceRepository.Add(p);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Experiences t = experienceRepository.Find(x => x.ID == id);
            experienceRepository.Delete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetExperience(int id)
        {
            Experiences t = experienceRepository.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult GetExperience(Experiences p)
        {
            Experiences t = experienceRepository.Find(x => x.ID == p.ID);
            t.Title = p.Title;
            t.CompanyName = p.CompanyName;
            t.Date = p.Date;
            t.Description = p.Description;
            experienceRepository.Update(t);
            return RedirectToAction("Index");
        }

        public ActionResult Active(int id)
        {
            Experiences t = experienceRepository.Find(x => x.ID == id);
            t.Status = true;
            experienceRepository.Update(t);
            return RedirectToAction("Index");
        }

        public ActionResult Passive(int id)
        {
            Experiences t = experienceRepository.Find(x => x.ID == id);
            t.Status = false;
            experienceRepository.Update(t);
            return RedirectToAction("Index");
        }
    }
}