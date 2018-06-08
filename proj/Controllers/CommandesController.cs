using Microsoft.AspNet.Identity;
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
                //TO call before creation of ligne commande

                // TODO: Add insert logic here
                Commande commande = new Commande();
                commande.dateCmd = DateTime.Now.ToString();
                commande.idClient = User.Identity.GetUserId();

                // TODO: Add insert logic here
                var message = ClientCall.client.PostAsJsonAsync("api/Commandes", commande).Result;
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Commandes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Commande collection)
        {
            try
            {
                // TODO: Add update logic here
                //on ne modifie pas une commande on modifie la ligne commande
                return RedirectToAction("Index");
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
        public ActionResult Delete(int id, Commande collection)
        {
            try
            {
                // TODO: Add delete logic here
                var message = ClientCall.client.DeleteAsync("api/Commandes/" + id).Result;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
