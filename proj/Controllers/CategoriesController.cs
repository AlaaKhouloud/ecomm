using proj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace proj.Controllers
{
    public class CategoriesController : Controller
    {
        private ASPPROJEntities db = new ASPPROJEntities();
        // GET: Categories
        public ActionResult Index()
        {
            HttpResponseMessage response = ClientCall.client.GetAsync("api/Categories").Result;
            IEnumerable<Categorie> liste = response.Content.ReadAsAsync<IEnumerable<Categorie>>().Result;

            return View(liste);
        }

        // GET: Categories/Details/5
        public ActionResult Details(string id)
        {
            
            Categorie cate = db.Categories.Find(id);
            return View(cate);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        public ActionResult Create(Categorie formCollection)
        {
            try
            {
                Categorie cat = new Categorie(formCollection.refCat, formCollection.nomcatg);
                // TODO: Add insert logic here
                var message = ClientCall.client.PostAsJsonAsync("api/Categories",cat).Result;
                if (message.IsSuccessStatusCode) return RedirectToAction("Index");
                else {
                    ViewData["eror"] = message.ReasonPhrase + " "+message.Content;
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(string id)
        {
            Categorie cate = db.Categories.Find(id);

            return View(cate);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Categorie formcollection)
        {
            try
            {
                // TODO: Add update logic here
                Categorie cat = new Categorie(id,formcollection.nomcatg);
                HttpResponseMessage response = ClientCall.client.PutAsJsonAsync("api/Categories/" + id, cat).Result;
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

        // GET: Categories/Delete/5
        public ActionResult Delete(string id)
        {
            Categorie cate = db.Categories.Find(id);
            
            return View(cate);
        }

        // POST: Categories/Delete/5
        [HttpPost]
        public ActionResult Delete(string id,Categorie c)
        {
            /*try
            {
               
                HttpResponseMessage response = ClientCall.client.DeleteAsync("api/Categories/" + id).Result;
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
            }*/
            Categorie cate = db.Categories.Find(id);
            db.Categories.Remove(cate);
            
            return RedirectToAction("Index");
        
       

        }
    }
}
