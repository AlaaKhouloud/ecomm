using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace proj.Models
{
    public static class ClientCall
    {
        public static HttpClient client;
        static ClientCall()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:59615/");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}