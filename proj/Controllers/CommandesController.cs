using proj.Models;
using proj.Service;
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
        ICommande _service;

        public CommandesController(ICommande service)
        {
            _service = service;
        }

        public CommandesController()
        {
            _service = new CommandeImpl();
        }

        // GET: Commandes
        public ViewResult Index()
        {
          
            return View("Index", _service.FIndAll());
        }

        // GET: Commandes/Details/5
        public ViewResult Details(int id)
        {
            return View("Details", _service.GetCommande(id));
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
        public ActionResult Edit(int id)
        {
            return View(_service.GetCommande(id));
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
