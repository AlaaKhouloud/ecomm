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
        public string prixU { get; set; }
        public Nullable<int> stock { get; set; }
        public string photo { get; set; }
        public string refCat { get; set; }

        public virtual Categorie Categorie { get; set; }

        public virtual ICollection<LigneCommande> LigneCommandes { get; set; }
    }
}