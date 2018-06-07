using proj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proj.Service
{
    public interface ICommande
    {
        IEnumerable<Commande> FIndAll();
    }
}
