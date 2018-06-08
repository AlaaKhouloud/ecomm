using proj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace proj.Service
{
    public class ArticleImpl : IArticlesSercice
    {
        public String Add(Article Article)
        {
            try
            {
                var message = ClientCall.client.PostAsJsonAsync("api/Articles", Article).Result;
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
                var message = ClientCall.client.DeleteAsync("api/Articles/" + refCat).Result;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public string Update(string id, Article Article)
        {
            try
            {
                HttpResponseMessage response = ClientCall.client.PutAsJsonAsync("api/Articles/" + id, Article).Result;
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

        public List<Article> FinAll()
        {
            HttpResponseMessage response = ClientCall.client.GetAsync("api/Articles").Result;
            List<Article> liste = response.Content.ReadAsAsync<List<Article>>().Result;
            return liste;
        }

        public Article FinOne(string refCat)
        {
            Article c;
            HttpResponseMessage respose = ClientCall.client.GetAsync("api/Articles/" + refCat).Result;
            c = respose.Content.ReadAsAsync<Article>().Result;
            return c;
        }
    }
}