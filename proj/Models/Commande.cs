using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proj.Models
{
    public class Commande
    {
        public int numCmd { get; set; }
        public string dateCmd { get; set; }
        public string idClient { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
        public virtual ICollection<LigneCommande> LigneCommandes { get; set; }

    }
}