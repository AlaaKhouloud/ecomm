using Microsoft.AspNet.Identity;
using proj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;

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
        //public ActionResult Create(int id , int qte)
        //{
        //    if (User.Identity.GetUserId() == null)
        //    {
        //        ViewBag.msg = "Vous n'etes pas connecter";
        //        return RedirectToAction("Login" , "Account");
        //    }
        //    else
        //    {
        //        HttpCookie cookie = new HttpCookie("coockie");
        //        cookie.Value = id+"";
        //        HttpCookie cookie2 = new HttpCookie("coockie2");
        //        cookie.Value = qte + "";
        //        this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
        //        this.ControllerContext.HttpContext.Response.Cookies.Add(cookie2);
        //        return View();
        //    }        
        //}



        // POST: LigneCommandes/Create
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Create(int id, int qte)
        {
            if (qte == null) qte = 1;
            if (User.Identity.GetUserId() == null)
            {
                ViewBag.msg = "Vous n'etes pas connecter. <a href='Account/Login'>Login</a>";
                return RedirectToAction("Login", "Account",ViewBag.msg);
            }
            else
            {
                Commande commande = new Commande();
                commande.dateCmd = DateTime.Now.ToShortDateString();
                commande.idClient = User.Identity.GetUserId();
                //insert
                var reponse = ClientCall.client.PostAsJsonAsync("api/Commandes", commande).Result;

                ////get last inserted id
                HttpResponseMessage response4 = ClientCall.client.GetAsync("api/Commandes/" + User.Identity.GetUserId()).Result;
                IEnumerable<Commande> liste4 = response4.Content.ReadAsAsync<IEnumerable<Commande>>().Result;
                int idcmd = liste4.Last().numCmd;

                ////make a command
                LigneCommande ligne = new LigneCommande();
                ligne.numCmd = idcmd;
                ligne.numArticle = id;
                ligne.QteArticle = qte;
                //trouver prix
                var message = ClientCall.client.GetAsync("api/Articles").Result;
                IEnumerable<Article> article = message.Content.ReadAsAsync<IEnumerable<Article>>().Result;
                foreach (var item in article)
                {
                    if (item.numArticle.Equals(ligne.numArticle))
                    {
                        ligne.totalPrice = double.Parse(item.prixU) * ligne.QteArticle;
                    }
                }

                //// insert the cmmand
                var response = ClientCall.client.PostAsJsonAsync("api/LigneCommandes", ligne).Result;
                if (!message.IsSuccessStatusCode || !response.IsSuccessStatusCode || !response4.IsSuccessStatusCode) ViewData["eror"] = message.ReasonPhrase + " " + message.Content;

                return RedirectToAction("Index", "Home");
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
                LigneCommande cat = new LigneCommande();
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

        // POST: LigneCommandes/Delete/5
        public ActionResult Delete(int id, LigneCommande collection)
        {
            try
            {
                // TODO: Add delete logic here
                var message = ClientCall.client.DeleteAsync("api/LigneCommandes/" + id).Result;

                return RedirectToAction("Index" , "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}