using proj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace proj.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ASPPROJEntities db = new ASPPROJEntities();
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult IndexAdmin()
        {
            ViewBag.f = new SelectList(db.Categories, "refCat", "nomcatg");
            return View();
        }
        public JsonResult GetArticleByRef(string ID)//ID: c'est id de la filiere selectionée
        {
            //Pour eviter les conflis entre les differents foreinkey de idfiliere
            //presentent dans la table etudiants
            db.Configuration.ProxyCreationEnabled = false;
            return Json(db.Articles.Where(p => p.refCat == ID), JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles ="Admin")]
        public ActionResult Administration()
        {
            ViewBag.Message = "Your admin panel.";

            return View();
        }
    }
}