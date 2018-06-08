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
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LigneCommandes/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult AddToPanier(LigneCommande formCollection)
        {
            //Ajouter des elements au panier
            //utiliser des coockies

            try
            {
                //Create list of ligncommands
                List<LigneCommande> data = new List<LigneCommande>();
                
                //trouver prix
                var message = ClientCall.client.PostAsJsonAsync("api/Articles", formCollection.numArticle).Result;
                Article article = message.Content.ReadAsAsync<Article>().Result;
                formCollection.totalPrice = double.Parse(article.prixU) * formCollection.QteArticle;
                //

                data.Add(formCollection);

                // convertir en un string pour permettre le stockage dans la coockie
                var monpanier = String.Join(",", data);
                // store cookie and redirect
                Response.Cookies.Add(new HttpCookie("monpanier", monpanier));

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // POST: LigneCommandes/Create
        [HttpPost]
        public ActionResult Create(LigneCommande formCollection)
        {
            //insert coockies/panier stuff into db and asscoiate commands to it
            try
            {
                // TODO: Add insert logic here
                //read monpanier to insert in into db after verification
                // Your cookie exists - grab your value and create your List
                // List<LigneCommande> panier = Request.Cookies["monpanier"].Value.Split(',').Select(x=>).ToList();


                // var message = ClientCall.client.PostAsJsonAsync("api/LigneCommandes", ligne).Result;
                //if (message.IsSuccessStatusCode) return RedirectToAction("Index");
                //else
                //{
                //    ViewData["eror"] = message.ReasonPhrase + " " + message.Content;
                //    return View();
                //}
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: LigneCommandes/Edit/5
        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: LigneCommandes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, LigneCommande collection)
        {
            try
            {
                
                //trouver prix
                var message = ClientCall.client.PostAsJsonAsync("api/Articles", collection.numArticle).Result;
                Article article = message.Content.ReadAsAsync<Article>().Result;
                collection.totalPrice = double.Parse(article.prixU) * collection.QteArticle;
                //
                collection.numLigne = id;
                HttpResponseMessage response = ClientCall.client.PutAsJsonAsync("api/LigneCommandes/" + id, collection).Result;
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
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var message = ClientCall.client.DeleteAsync("api/LigneCommandes/" + id).Result;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
