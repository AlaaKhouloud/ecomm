using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proj.Models
{
    public class LigneCommande
    {
        public int numLigne { get; set; }
        public int idArticle { get; set; }
        public virtual Article article { get; set; }

        public int QteArticle;
    }
}