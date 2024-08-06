using MyResumeWebsite.Models.Entity;
using MyResumeWebsite.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyResumeWebsite.Controllers
{
    public class DashboardController : Controller
    {
        GenericRepository<AboutMe> aboutMeRepository = new GenericRepository<AboutMe>();
        GenericRepository<Experiences> experienceRepository = new GenericRepository<Experiences>();
        GenericRepository<Educations> educationRepository = new GenericRepository<Educations>();
        GenericRepository<Skills> skillRepository = new GenericRepository<Skills>();
        GenericRepository<Certificates> certificateRepository = new GenericRepository<Certificates>();
        GenericRepository<Projects> projectRepository = new GenericRepository<Projects>();
        GenericRepository<SocialMedia> socialMediaRepository = new GenericRepository<SocialMedia>();
        GenericRepository<Contact> contactRepository = new GenericRepository<Contact>();
        GenericRepository<Admin> adminRepository = new GenericRepository<Admin>();

        public ActionResult Index()
        {
            var aboutMe = aboutMeRepository.List();
            return View(aboutMe);
        }

        public PartialViewResult Experiences()
        {
            var experiencesCount = experienceRepository.List().Count();
            return PartialView(experiencesCount);
        }

        public PartialViewResult Educations()
        {
            var educationsCount = educationRepository.List().Count();
            return PartialView(educationsCount);
        }

        public PartialViewResult Skills()
        {
            var skillsCount = skillRepository.List().Count();
            return PartialView(skillsCount);
        }

        public PartialViewResult Certificates()
        {
            var certificatesCount = certificateRepository.List().Count();
            return PartialView(certificatesCount);
        }

        public PartialViewResult Projects()
        {
            var projectsCount = projectRepository.List().Count();
            return PartialView(projectsCount);
        }

        public PartialViewResult SocialMediaAccounts()
        {
            var socialMediaAccountsCount = socialMediaRepository.List().Where(x => x.Status == true).Count();
            return PartialView(socialMediaAccountsCount);
        }

        public PartialViewResult Messages()
        {
            var messagesCount = contactRepository.List().Count();
            return PartialView(messagesCount);
        }

        public PartialViewResult Admins()
        {
            var adminsCount = adminRepository.List().Count();
            return PartialView(adminsCount);
        }
    }
}