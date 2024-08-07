using MyResumeWebsite.Models.Entity;
using MyResumeWebsite.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyResumeWebsite.Controllers
{
    public class ProjectController : Controller
    {
        GenericRepository<Projects> repo = new GenericRepository<Projects>();

        public ActionResult Index()
        {
            var projects = repo.List();
            return View(projects);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Projects p)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }

            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "/images/projects/" + fileName + extension;

                Request.Files[0].SaveAs(Server.MapPath(path));
                p.Picture = "/images/projects/" + fileName + extension;
            }

            repo.Add(p);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var project = repo.Find(x => x.ID == id);

            var filePath = Server.MapPath(project.Picture);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            repo.Delete(project);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var project = repo.Find(x => x.ID == id);
            return View(project);
        }

        [HttpPost]
        public ActionResult Edit(Projects t)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit");
            }

            var project = repo.Find(x => x.ID == t.ID);

            project.Title = t.Title;
            project.Subtitle = t.Subtitle;
            project.Description = t.Description;
            project.Date = t.Date;

            var filePath = Server.MapPath(project.Picture);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "/images/projects/" + fileName + extension;

                Request.Files[0].SaveAs(Server.MapPath(path));
                project.Picture = "/images/projects/" + fileName + extension;
            }

            repo.Update(project);
            return RedirectToAction("Index");
        }

        public ActionResult Active(int id)
        {
            Projects t = repo.Find(x => x.ID == id);
            t.Status = true;
            repo.Update(t);
            return RedirectToAction("Index");
        }

        public ActionResult Passive(int id)
        {
            Projects t = repo.Find(x => x.ID == id);
            t.Status = false;
            repo.Update(t);
            return RedirectToAction("Index");
        }
    }
}