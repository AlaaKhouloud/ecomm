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
    public class ArticlesController : Controller
    {
        // GET: Articles
        public ActionResult Index()
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
            UserView vu = new UserView();
            vu.articles = liste;
            vu.categories = liste2;
            vu.ligneCommandes = liste3;
            vu.Commandes = liste4;
            return View(vu);

        }

        // GET: Articles/Details/5
        public ActionResult Details(string id)
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

            List<Article> search = new List<Article>();
            Article art = new Article();
            foreach (var item in liste.ToList())
            {
                if(item.refCat == id)
                {
                    art.numArticle = item.numArticle;
                    art.photo = item.photo;
                    art.prixU = item.prixU;
                    art.stock = item.stock;
                    art.refCat = item.refCat;
                    art.designation = item.designation;
                    search.Add(art);
                }
            }

            UserView vu = new UserView();
            vu.articles = liste;
            vu.categories = liste2;
            vu.ligneCommandes = liste3;
            vu.Commandes = liste4;
            vu.searchbycat = search;
            return View(vu);
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        [HttpPost]
        public ActionResult Create(Article formCollection)
        {
            try
            {
                Article cat = new Article(formCollection.numArticle,formCollection.designation,formCollection.prixU,formCollection.stock,formCollection.photo,formCollection.refCat,formCollection.Categorie,formCollection.LigneCommandes);
                // TODO: Add insert logic here
                var message = ClientCall.client.PostAsJsonAsync("api/Articles", cat).Result;
                if (message.IsSuccessStatusCode) return RedirectToAction("Index");
                else
                {
                    ViewData["eror"] = message.ReasonPhrase + " " + message.Content;
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(string id)
        {
            return View();
        }

        // POST: Articles/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Article formCollection)
        {
            int id2 = Convert.ToInt32(id);
            try
            {
                // TODO: Add update logic here
                Article cat = new Article(id2, formCollection.designation, formCollection.prixU, formCollection.stock, formCollection.photo, formCollection.refCat, formCollection.Categorie, formCollection.LigneCommandes);
                HttpResponseMessage response = ClientCall.client.PutAsJsonAsync("api/Articles/" + id, cat).Result;
                if (response.IsSuccessStatusCode) return RedirectToAction("Index");
                else
                {
                    ViewData["eror"] = response.ReasonPhrase + " " + response.Content;
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    

        // GET: Articles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Articles/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            int id2 = Convert.ToInt32(id);
            try
            {
                // TODO: Add delete logic here
                var message = ClientCall.client.DeleteAsync("api/Articles/" + id2).Result;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
