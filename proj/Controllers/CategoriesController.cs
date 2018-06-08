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
    public class CategoriesController : Controller
    {
        CategorieServiceImpl service = new CategorieServiceImpl();

        // GET: Categories
        public ActionResult Index()
        {
            IEnumerable<Categorie> liste = service.FinAll();

            return View(liste);
        }

        // GET: Categories/Details/5
        public ActionResult Details(string id)
        {
            Categorie categorie = service.FinOne(id);
            return View(categorie);
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
            string result = service.Add(formCollection);
            if (result.Equals("true"))
            {
                return RedirectToAction("Index");
            }
            else if (result.Equals("false"))
            {
                return View();
            }
            ViewData["eror"] = result;
            return View();
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(string id)
        {
            return View(service.FinOne(id));
        }

        // POST: Categories/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Categorie formcollection)
        {
            string result = service.Update(id, formcollection);
            if (result.Equals("true"))
            {
                return RedirectToAction("Index");
            }
            else if (result.Equals("false"))
            {
                return View();
            }
            ViewData["eror"] = result;
            return View();
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(string id)
        {

            return View(service.FinOne(id));
        }

        // POST: Categories/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            if (service.Remove(id))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
