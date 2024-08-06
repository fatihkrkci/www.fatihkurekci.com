using MyResumeWebsite.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyResumeWebsite.Repositories;

namespace MyResumeWebsite.Controllers
{
    public class SkillController : Controller
    {
        GenericRepository<Skills> repo = new GenericRepository<Skills>();
        
        public ActionResult Index()
        {
            var skills = repo.List();
            return View(skills);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Skills p)
        {
            repo.Add(p);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var skill = repo.Find(x=>x.ID == id);
            repo.Delete(skill);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var skill = repo.Find(x => x.ID == id);
            return View(skill);
        }

        [HttpPost]
        public ActionResult Edit(Skills t)
        {
            var skill = repo.Find(x => x.ID == t.ID);
            skill.Skill = t.Skill;
            skill.Rate = t.Rate;
            repo.Update(t);
            return RedirectToAction("Index");
        }

        public ActionResult Active(int id)
        {
            Skills t = repo.Find(x => x.ID == id);
            t.Status = true;
            repo.Update(t);
            return RedirectToAction("Index");
        }

        public ActionResult Passive(int id)
        {
            Skills t = repo.Find(x => x.ID == id);
            t.Status = false;
            repo.Update(t);
            return RedirectToAction("Index");
        }
    }
}