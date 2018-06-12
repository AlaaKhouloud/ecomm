using proj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace proj.Controllers
{
    public class StatistiquesController : Controller
    {
        // GET: Statistiques
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PieChart()
        {
            IDictionary<String, int> dic = new Dictionary<String, int>();
            ASPPROJEntities db = new ASPPROJEntities();
            List<Categorie> catList = db.Categories.ToList();
            foreach (Categorie c in catList)
            {
                int Count = db.Articles.Count(o => o.refCat == c.refCat);
                dic.Add(c.nomcatg, Count);
            }
         
            new Chart(width: 500, height: 500).AddTitle("Le pourcentage d'articles par catégorie")
                .AddSeries(chartType: "Pie", xValue: dic.Keys, yValues: dic.Values).Write("png");

            return null;
        }

        public ActionResult ColumnChart()
        {
            IDictionary<String, int?> dic = new Dictionary<String, int?>();
            ASPPROJEntities db = new ASPPROJEntities();
            List<Article> ArtList = db.Articles.ToList();
            foreach(Article article in ArtList)
            {
                dic.Add(article.designation, article.stock);
            }
            new System.Web.Helpers.Chart(width: 800, height: 200).AddTitle("Le nombre de piece dans chaque article")
                .AddSeries(chartType: "column", xValue:dic.Keys, yValues:dic.Values).Write("png");
            
            return null;
        }
    }
}