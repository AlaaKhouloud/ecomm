using Microsoft.AspNet.Identity;
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
            HttpResponseMessage response3 = ClientCall.client.GetAsync("api/LigneCommandes").Result;
            IEnumerable<LigneCommande> liste3 = response3.Content.ReadAsAsync<IEnumerable<LigneCommande>>().Result;
            HttpResponseMessage response4 = ClientCall.client.GetAsync("api/Commandes/"+User.Identity.GetUserId()).Result;
            IEnumerable<Commande> liste4 = response4.Content.ReadAsAsync<IEnumerable<Commande>>().Result;
            foreach (var item in liste3.ToList())
            {
                foreach (var item2 in liste.ToList())
                {
                    if(item.numArticle == item2.numArticle)
                    {
                        item.Article = new Article();
                        item.Article.photo = item2.photo;
                        item.Article.designation = item2.designation;
                    }
                }
            } 
            UserView vu = new UserView();
            vu.articles = liste;
            vu.categories = liste2;
            vu.ligneCommandes = liste3;
            vu.Commandes = liste4;
            return View(vu);
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

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            HttpResponseMessage response = ClientCall.client.GetAsync("api/Articles").Result;
            IEnumerable<Article> liste = response.Content.ReadAsAsync<IEnumerable<Article>>().Result;
            HttpResponseMessage response2 = ClientCall.client.GetAsync("api/Categories").Result;
            IEnumerable<Categorie> liste2 = response2.Content.ReadAsAsync<IEnumerable<Categorie>>().Result;
            HttpResponseMessage response3 = ClientCall.client.GetAsync("api/LigneCommandes").Result;
            IEnumerable<LigneCommande> liste3 = response3.Content.ReadAsAsync<IEnumerable<LigneCommande>>().Result;
            HttpResponseMessage response4 = ClientCall.client.GetAsync("api/Commandes/" + User.Identity.GetUserId()).Result;
            IEnumerable<Commande> liste4 = response4.Content.ReadAsAsync<IEnumerable<Commande>>().Result;
            foreach (var item in liste3.ToList())
            {
                foreach (var item2 in liste.ToList())
                {
                    if (item.numArticle == item2.numArticle)
                    {
                        item.Article = new Article();
                        item.Article.photo = item2.photo;
                        item.Article.designation = item2.designation;
                    }
                }
            }
            
            Article article = new Article();
            foreach (var item in liste)
            {
                if(item.numArticle == id)
                {
                    article.designation = item.designation;
                    article.photo = item.photo;
                    article.prixU = item.prixU;
                    article.stock = item.stock; 
                }
            }

            UserView vu = new UserView();
            vu.articles = liste;
            vu.categories = liste2;
            vu.ligneCommandes = liste3;
            vu.Commandes = liste4;
            vu.article = article;

            return View(vu);
        }
    }
}