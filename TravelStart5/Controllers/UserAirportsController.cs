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
    public class UserAirportsController : ApiController
    {
        private EntitiesUserAirport db = new EntitiesUserAirport();

        // GET: api/UserAirports
        public IQueryable<UserAirport> GetUserAirports()
        {
            return db.UserAirports;
        }

        // GET: api/UserAirports/5
        [ResponseType(typeof(UserAirport))]
        public IHttpActionResult GetUserAirport(string id)
        {
            UserAirport userAirport = db.UserAirports.Find(id);
            if (userAirport == null)
            {
                return NotFound();
            }

            return Ok(userAirport);
        }

        // PUT: api/UserAirports/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserAirport(string id, UserAirport userAirport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userAirport.UserId)
            {
                return BadRequest();
            }

            db.Entry(userAirport).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAirportExists(id))
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

        // POST: api/UserAirports
        [AllowAnonymous]
        [ResponseType(typeof(UserAirport))]
        public IHttpActionResult PostUserAirport(UserAirport userAirport)
        {
         

            db.UserAirports.Add(userAirport);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UserAirportExists(userAirport.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = userAirport.UserId }, userAirport);
        }

        // DELETE: api/UserAirports/5
        [ResponseType(typeof(UserAirport))]
        public IHttpActionResult DeleteUserAirport(string id)
        {
            UserAirport userAirport = db.UserAirports.Find(id);
            if (userAirport == null)
            {
                return NotFound();
            }

            db.UserAirports.Remove(userAirport);
            db.SaveChanges();

            return Ok(userAirport);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserAirportExists(string id)
        {
            return db.UserAirports.Count(e => e.UserId == id) > 0;
        }
    }
}