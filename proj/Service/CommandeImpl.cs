using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using proj.Models;

namespace proj.Service
{
    public class CommandeImpl : ICommande
    {
       
        public IEnumerable<Commande> FIndAll()
        {
            HttpResponseMessage response = ClientCall.client.GetAsync("api/Commandes").Result;
            IEnumerable<Commande> liste = response.Content.ReadAsAsync<IEnumerable<Commande>>().Result;
            return liste;
        }
    }
}