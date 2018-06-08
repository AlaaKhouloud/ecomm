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
    public class ArticlesController : Controller
    {
        IArticlesSercice _service;

        public ArticlesController(IArticlesSercice service)
        {
            _service = service;
        }
        public ArticlesController()
        {
            _service = new ArticleImpl();
        }

        // GET: Articles
        public ActionResult Index()
        {
            return View(_service.FinAll());
        }

        // GET: Articles/Details/5
        public ActionResult Details(int id)
        {
            return View(_service.FinOne(id.ToString()));
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        [HttpPost]
        public ActionResult Create(Article formCollection)
        {
            string result = _service.Add(formCollection);
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

        // GET: Articles/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_service.FinOne(id.ToString()));
        }

        // POST: Articles/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Article formcollection)
        {
            string result = _service.Update(id.ToString(), formcollection);
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

        // GET: Articles/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_service.FinOne(id.ToString()));
        }

        // POST: Articles/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (_service.Remove(id.ToString()))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
