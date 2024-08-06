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
    public class CertificateController : Controller
    {
        GenericRepository<Certificates> repo = new GenericRepository<Certificates>();

        public ActionResult Index()
        {
            var certificate = repo.List();
            return View(certificate);
        }

        [HttpGet]
        public ActionResult GetCertificate(int id)
        {
            var certificate = repo.Find(x => x.ID == id);
            return View(certificate);
        }

        [HttpPost]
        public ActionResult GetCertificate(Certificates t)
        {
            var certificate = repo.Find(x => x.ID == t.ID);
            certificate.Name = t.Name;
            certificate.Foundation = t.Foundation;

            var filePath = Server.MapPath(certificate.Picture);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "/images/certificates/" + fileName + extension;

                Request.Files[0].SaveAs(Server.MapPath(path));
                certificate.Picture = "/images/certificates/" + fileName + extension;
            }

            repo.Update(certificate);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Certificates p)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "/images/certificates/" + fileName + extension;

                Request.Files[0].SaveAs(Server.MapPath(path));
                p.Picture = "/images/certificates/" + fileName + extension;
            }

            repo.Add(p);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var certificate = repo.Find(x => x.ID == id);

            var filePath = Server.MapPath(certificate.Picture);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            repo.Delete(certificate);
            return RedirectToAction("Index");
        }

        public ActionResult Active(int id)
        {
            Certificates t = repo.Find(x => x.ID == id);
            t.Status = true;
            repo.Update(t);
            return RedirectToAction("Index");
        }

        public ActionResult Passive(int id)
        {
            Certificates t = repo.Find(x => x.ID == id);
            t.Status = false;
            repo.Update(t);
            return RedirectToAction("Index");
        }
    }
}