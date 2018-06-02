using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proj.Models
{
    public class LigneCommande
    {
        public int numLigne { get; set; }
        public Nullable<int> QteArticle { get; set; }
        public Nullable<double> totalPrice { get; set; }
        public Nullable<int> numCmd { get; set; }
        public Nullable<int> numArticle { get; set; }

        public virtual Article Article { get; set; }
        public virtual Commande Commande { get; set; }
    }
}