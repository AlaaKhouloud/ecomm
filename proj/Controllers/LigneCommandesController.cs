using proj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace proj.Controllers
{
    public class LigneCommandesController : Controller
    {
        // GET: LigneCommandes
        public ActionResult Index()
        {
            HttpResponseMessage response = ClientCall.client.GetAsync("api/LigneCommandes").Result;
            IEnumerable<LigneCommande> liste = response.Content.ReadAsAsync<IEnumerable<LigneCommande>>().Result;

            return View(liste);
        }

        // GET: LigneCommandes/Details/5
        public ActionResult Details(string id)
        {
            return View();
        }

        // GET: LigneCommandes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LigneCommandes/Create
        [HttpPost]
        public ActionResult Create(LigneCommande formCollection)
        {
            try
            {
                
                LigneCommande cat = new LigneCommande(formCollection.numLigne, formCollection.QteArticle, formCollection.totalPrice, formCollection.numCmd, formCollection.numArticle, formCollection.Article, formCollection.Commande);
                // TODO: Add insert logic here
                var message = ClientCall.client.PostAsJsonAsync("api/LigneCommandes", cat).Result;
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

        // GET: LigneCommandes/Edit/5
        public ActionResult Edit(string id)
        {
            return View();
        }

        // POST: LigneCommandes/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, LigneCommande formCollection)
        {
            int id2 = Convert.ToInt32(id);
            try
            {
                // TODO: Add update logic here
                LigneCommande cat = new LigneCommande(id2, formCollection.QteArticle, formCollection.totalPrice, formCollection.numCmd, formCollection.numArticle, formCollection.Article, formCollection.Commande);
                HttpResponseMessage response = ClientCall.client.PutAsJsonAsync("api/LigneCommandes/" + id, cat).Result;
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


        // GET: LigneCommandes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LigneCommandes/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            int id2 = Convert.ToInt32(id);
            try
            {
                // TODO: Add delete logic here
                var message = ClientCall.client.DeleteAsync("api/LigneCommandes/" + id2).Result;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}