using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using proj.Models;

namespace proj.Service
{
    public class CategorieServiceImpl : ICategorieService
    {


        public String Add(Categorie categorie)
        {
            try
            {
                var message = ClientCall.client.PostAsJsonAsync("api/Categories", categorie).Result;
                if (message.IsSuccessStatusCode) return "true";
                else
                {
                    return message.ReasonPhrase + " " + message.Content; ;
                }
            }
            catch
            {
                return "false";
            }
        }

        public bool Remove(string refCat)
        {
            try
            {
                // TODO: Add delete logic here
                var message = ClientCall.client.DeleteAsync("api/Categories/" + refCat).Result;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public string Update(string id, Categorie categorie)
        {
            try
            {
                HttpResponseMessage response = ClientCall.client.PutAsJsonAsync("api/Categories/" + id, categorie).Result;
                if (response.IsSuccessStatusCode) return "true";
                else
                {
                    //ViewData["eror"] = ;
                    return response.ReasonPhrase + " " + response.Content;
                }
            }
            catch
            {
                return "false";
            }
        }

        public List<Categorie> FinAll()
        {
            HttpResponseMessage response = ClientCall.client.GetAsync("api/Categories").Result;
            List<Categorie> liste = response.Content.ReadAsAsync<List<Categorie>>().Result;
            return liste;
        }

        public Categorie FinOne(string refCat)
        {
            Categorie c;
            HttpResponseMessage respose = ClientCall.client.GetAsync("api/Categories/" + refCat).Result;
            c = respose.Content.ReadAsAsync<Categorie>().Result;
            return c;
        }

    }
}