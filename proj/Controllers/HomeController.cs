using proj.Models;
using proj.Models.others;
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
        [AllowAnonymous]
        public ActionResult Index()
        {
            HttpResponseMessage response = ClientCall.client.GetAsync("api/Articles").Result;
            IEnumerable<Article> liste = response.Content.ReadAsAsync<IEnumerable<Article>>().Result;
            HttpResponseMessage response2 = ClientCall.client.GetAsync("api/Categories").Result;
            IEnumerable<Categorie> liste2 = response2.Content.ReadAsAsync<IEnumerable<Categorie>>().Result;
            UserView vu = new UserView();
            vu.articles = liste;
            vu.categories = liste2;
            return View(vu);
        }
        [AllowAnonymous]
        public ActionResult Details()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult IndexAdmin()
        {
            return View();
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