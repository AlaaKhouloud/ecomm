using proj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace proj.Controllers
{
    public class AdminArtController : Controller
    {
        // GET: Articles
        public ActionResult Index()
        {
            HttpResponseMessage response = ClientCall.client.GetAsync("api/AdminArt").Result;
            IEnumerable<Article> liste = response.Content.ReadAsAsync<IEnumerable<Article>>().Result;

            return View(liste);
        }

        public ActionResult IndexAdmin()
        {
            HttpResponseMessage response = ClientCall.client.GetAsync("api/AdminArt").Result;
            IEnumerable<Article> liste = response.Content.ReadAsAsync<IEnumerable<Article>>().Result;

            return View(liste);
        }

        public ActionResult DetailsAdmin(string id)
        {
            return View();
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            HttpResponseMessage response = ClientCall.client.GetAsync("api/AdminCat").Result;
            IEnumerable<Categorie> liste = response.Content.ReadAsAsync<IEnumerable<Categorie>>().Result;
            ViewBag.reference = new SelectList(liste, "refCat", "nomcatg");
            return View();
        }

        // POST: Articles/Create
        [HttpPost]
        public ActionResult Create(Article formCollection)
        {
            try
            {
                Article cat = new Article(formCollection.numArticle, formCollection.designation, formCollection.prixU, formCollection.stock, formCollection.photo, formCollection.refCat, formCollection.Categorie, formCollection.LigneCommandes);
                // TODO: Add insert logic here
                var message = ClientCall.client.PostAsJsonAsync("api/AdminArt", cat).Result;
                if (message.IsSuccessStatusCode) return RedirectToAction("IndexAdmin");
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
        public ActionResult Edit(int id, Article formCollection)
        {
            try
            {
                // TODO: Add update logic here
                Article cat = new Article(id, formCollection.designation, formCollection.prixU, formCollection.stock, formCollection.photo, formCollection.refCat, formCollection.Categorie, formCollection.LigneCommandes);
                HttpResponseMessage response = ClientCall.client.PutAsJsonAsync("api/AdminArt/" + id, cat).Result;
                if (response.IsSuccessStatusCode) return RedirectToAction("IndexAdmin");
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
                var message = ClientCall.client.DeleteAsync("api/AdminArt/" + id2).Result;

                return RedirectToAction("IndexAdmin");
            }
            catch
            {
                return View();
            }
        }
    }
}