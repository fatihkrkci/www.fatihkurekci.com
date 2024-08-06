using MyResumeWebsite.Models.Entity;
using MyResumeWebsite.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyResumeWebsite.Controllers
{
    public class EducationController : Controller
    {
        GenericRepository<Educations> repo = new GenericRepository<Educations>();

        public ActionResult Index()
        {
            var educations = repo.List();
            return View(educations);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Educations p)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }
            repo.Add(p);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var education = repo.Find(x => x.ID == id);
            repo.Delete(education);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var education = repo.Find(x=>x.ID == id);
            return View(education);
        }

        [HttpPost]
        public ActionResult Edit(Educations t)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit");
            }
            var education = repo.Find(x => x.ID == t.ID);
            education.Department = t.Department;
            education.SchoolName = t.SchoolName;
            education.Date = t.Date;
            education.Description = t.Description;
            repo.Update(education);
            return RedirectToAction("Index");
        }

        public ActionResult Active(int id)
        {
            Educations t = repo.Find(x => x.ID == id);
            t.Status = true;
            repo.Update(t);
            return RedirectToAction("Index");
        }

        public ActionResult Passive(int id)
        {
            Educations t = repo.Find(x => x.ID == id);
            t.Status = false;
            repo.Update(t);
            return RedirectToAction("Index");
        }
    }
}