using proj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proj.Service
{
    public interface IArticlesSercice
    {
        List<Article> FinAll();
        Article FinOne(string refCat);
        string Update(string id, Article categorie);
        string Add(Article categorie);
        bool Remove(string refCat);
    }
}
