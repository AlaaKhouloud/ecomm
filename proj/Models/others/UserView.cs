using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proj.Models.others
{
    public class UserView
    {
        public IEnumerable<Article> articles { get; set; }
        public IEnumerable<Categorie> categories { get; set; }

        public IEnumerable<LigneCommande> ligneCommandes { get; set; }
        public IEnumerable<Commande> Commandes { get; set; }

        public Article article { get; set; }

        public List<Article> searchbycat { get; set; }


    }
}