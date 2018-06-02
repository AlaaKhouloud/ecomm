using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proj.Models
{
    public class Article
    {
        public int numArticle { get; set; }
        public string designation { get; set; }

        public double prixU { get; set; }

        public int stock { get; set; }

        public string photo { get; set; }

        public virtual Categorie categorie { get; set; }
    }
}