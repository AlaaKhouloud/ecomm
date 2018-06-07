using proj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace proj.Controllers
{
    public class CommandesController : Controller
    {
        // GET: Commandes
        public ActionResult Index()
        {
            HttpResponseMessage response = ClientCall.client.GetAsync("api/Commandes").Result;
            IEnumerable<Commande> liste = response.Content.ReadAsAsync<IEnumerable<Commande>>().Result;

            return View(liste);
        }

        // GET: Commandes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Commandes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Commandes/Create
        [HttpPost]
        public ActionResult Create(Commande formCollection)
        {
            try
            {
                Commande cat = new Commande(formCollection.numCmd, formCollection.dateCmd, formCollection.idClient, formCollection.AspNetUser,formCollection.LigneCommandes);
                // TODO: Add insert logic here
                var message = ClientCall.client.PostAsJsonAsync("api/Commandes", cat).Result;
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

        // GET: Commandes/Edit/5
        public ActionResult Edit(string id)
        {
            return View();
        }

        // POST: Commandes/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Commande formCollection)
        {
            int id2 = Convert.ToInt32(id);
            try
            {
                // TODO: Add update logic here
                Commande cat = new Commande(id2, formCollection.dateCmd, formCollection.idClient, formCollection.AspNetUser, formCollection.LigneCommandes);
                HttpResponseMessage response = ClientCall.client.PutAsJsonAsync("api/Commandes/" + id, cat).Result;
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


        // GET: Commandes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Commandes/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            int id2 = Convert.ToInt32(id);
            try
            {
                // TODO: Add delete logic here
                var message = ClientCall.client.DeleteAsync("api/Commandes/" + id2).Result;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
}