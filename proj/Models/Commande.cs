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
        public int idClient { get; set; }
        public ICollection<LigneCommande> ligneCommandes { get; set; }
        public float totalPrice;

    }
}