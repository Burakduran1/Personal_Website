using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db= new DbCvEntities();
        public ActionResult Index()
        {
            var degerler = db.Abouts.ToList();
            return View(degerler);
        }

        public PartialViewResult Experience()
        {
            var experience = db.Experiences.ToList();
            return PartialView(experience);
        }

        public PartialViewResult Education()
        {
            var education = db.Educations.ToList();
            return PartialView(education);
        }

        public PartialViewResult Skill()
        {
            var skill = db.SKILLS.ToList();
            return PartialView(skill);
        }

        public PartialViewResult Interest()
        {
            var interest = db.Interests.ToList();
            return PartialView(interest);
        }

        public PartialViewResult Award()
        {
            var avards = db.Awards.ToList();
            return PartialView(avards);
        }

        [HttpGet] /*Page loading*/
        public PartialViewResult Contact()
        {
            return PartialView();
        }
        [HttpPost] /*Page Action*/
        public PartialViewResult Contact(Communicaiton c)
        {
            c.Date = DateTime.Parse(DateTime.Now.ToString());
            db.Communicaitons.Add(c);
            db.SaveChanges();
            return PartialView();
        }

    }
}