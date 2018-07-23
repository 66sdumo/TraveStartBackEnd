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
    public class UserFlightsController : ApiController
    {
        private EntitiesUserFlight db = new EntitiesUserFlight();

        // GET: api/UserFlights
        public IQueryable<UserFlight> GetUserFlights()
        {
            return db.UserFlights;
        }

        // GET: api/UserFlights/5
        [ResponseType(typeof(UserFlight))]
        public IHttpActionResult GetUserFlight(string id)
        {
            UserFlight userFlight = db.UserFlights.Find(id);
            if (userFlight == null)
            {
                return NotFound();
            }

            return Ok(userFlight);
        }

        // PUT: api/UserFlights/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserFlight(string id, UserFlight userFlight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userFlight.UserId)
            {
                return BadRequest();
            }

            db.Entry(userFlight).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserFlightExists(id))
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

        // POST: api/UserFlights
        [AllowAnonymous]
        [ResponseType(typeof(UserFlight))]
        public IHttpActionResult PostUserFlight(UserFlight userFlight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserFlights.Add(userFlight);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UserFlightExists(userFlight.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = userFlight.UserId }, userFlight);
        }

        // DELETE: api/UserFlights/5
        [ResponseType(typeof(UserFlight))]
        public IHttpActionResult DeleteUserFlight(string id)
        {
            UserFlight userFlight = db.UserFlights.Find(id);
            if (userFlight == null)
            {
                return NotFound();
            }

            db.UserFlights.Remove(userFlight);
            db.SaveChanges();

            return Ok(userFlight);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserFlightExists(string id)
        {
            return db.UserFlights.Count(e => e.UserId == id) > 0;
        }
    }
}