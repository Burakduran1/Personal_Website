using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        ExperinceRepository repo = new ExperinceRepository();
        public ActionResult Index()
        {
            var value = repo.List();
            return View(value);
        }

        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(Experience p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExperience(int id)
        {
            Experience t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult EditExperience(int id)
        {
            Experience t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult EditExperience(Experience p)
        {
            Experience t = repo.Find(x => x.ID == p.ID);
            t.Title = p.Title;
            t.SubTitle = p.SubTitle;
            t.Date = p.Date;
            t.Description = p.Description;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}