using proj.Models;
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
        private ASPPROJEntities db = new ASPPROJEntities();
        // GET: Articles
       

        public ActionResult Index()
        {
            HttpResponseMessage response = ClientCall.client.GetAsync("api/Articles").Result;
            IEnumerable<Article> liste = response.Content.ReadAsAsync<IEnumerable<Article>>().Result;

            return View(liste);
        }

        // GET: Articles/Details/5
        public ActionResult Details(int id)
        {
            Article article = db.Articles.Find(id);
            return View(article);
        }

       

        // GET: Articles/Create
        public ActionResult Create()
        {
            HttpResponseMessage response = ClientCall.client.GetAsync("api/Categories").Result;
            IEnumerable<Categorie> liste = response.Content.ReadAsAsync<IEnumerable<Categorie>>().Result;
            ViewBag.refCat = new SelectList(liste, "refCat", "nomcatg");
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
        
        public ActionResult Edit(int id)
        {
            HttpResponseMessage response2 = ClientCall.client.GetAsync("api/Categories").Result;
            IEnumerable<Categorie> liste = response2.Content.ReadAsAsync<IEnumerable<Categorie>>().Result;
            ViewBag.refCat = new SelectList(liste, "refCat", "nomcatg");
            Article article = db.Articles.Find(id);
            return View(article);
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
            Article article = db.Articles.Find(id);
            return View(article);
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
