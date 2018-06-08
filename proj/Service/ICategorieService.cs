using proj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace proj.Service
{
    public interface ICategorieService
    {
        List<Categorie> FinAll();
        Categorie FinOne(string refCat);
        string Update(string id, Categorie categorie);
        string Add(Categorie categorie);
        bool Remove(string refCat);


    }
}