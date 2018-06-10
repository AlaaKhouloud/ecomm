using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using api.Models;

namespace api.Controllers
{
    public class CommandesController : ApiController
    {
        private ASPPROJEntities db = new ASPPROJEntities();

        // GET: api/Commandes
        public IQueryable<Commande> GetCommandes()
        {
            return db.Commandes;
        }

        // GET: api/Commandes/5
        [ResponseType(typeof(IEnumerable<Commande>))]
        public IEnumerable<Commande> GetCommande(string id)
        {
            return db.Commandes.Where(c=>c.idClient == id).ToList();
        }

        // PUT: api/Commandes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCommande(int id, Commande commande)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != commande.numCmd)
            {
                return BadRequest();
            }

            db.Entry(commande).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommandeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Commandes
        [ResponseType(typeof(Commande))]
        public IHttpActionResult PostCommande(Commande commande)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Commandes.Add(commande);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = commande.numCmd }, commande);
        }

        // DELETE: api/Commandes/5
        [ResponseType(typeof(Commande))]
        public IHttpActionResult DeleteCommande(int id)
        {
            Commande commande = db.Commandes.Find(id);
            if (commande == null)
            {
                return NotFound();
            }

            db.Commandes.Remove(commande);
            db.SaveChanges();

            return Ok(commande);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommandeExists(int id)
        {
            return db.Commandes.Count(e => e.numCmd == id) > 0;
        }
    }
}