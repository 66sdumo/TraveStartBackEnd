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
using TravelStart5.Models;

namespace TravelStart5.Controllers
{
    public class TravellersController : ApiController
    {
        private EntitiesTraveller db = new EntitiesTraveller();

        // GET: api/Travellers
        public IQueryable<Traveller> GetTravellers()
        {
            return db.Travellers;
        }

        // GET: api/Travellers/5
        [ResponseType(typeof(Traveller))]
        public IHttpActionResult GetTraveller(int id)
        {
            Traveller traveller = db.Travellers.Find(id);
            if (traveller == null)
            {
                return NotFound();
            }

            return Ok(traveller);
        }

        // PUT: api/Travellers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTraveller(int id, Traveller traveller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != traveller.TravellerID)
            {
                return BadRequest();
            }

            db.Entry(traveller).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravellerExists(id))
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

        // POST: api/Travellers
        [AllowAnonymous]
        [ResponseType(typeof(Traveller))]
        public IHttpActionResult PostTraveller(Traveller traveller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Travellers.Add(traveller);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = traveller.TravellerID }, traveller);
        }

        // DELETE: api/Travellers/5
        [ResponseType(typeof(Traveller))]
        public IHttpActionResult DeleteTraveller(int id)
        {
            Traveller traveller = db.Travellers.Find(id);
            if (traveller == null)
            {
                return NotFound();
            }

            db.Travellers.Remove(traveller);
            db.SaveChanges();

            return Ok(traveller);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TravellerExists(int id)
        {
            return db.Travellers.Count(e => e.TravellerID == id) > 0;
        }
    }
}