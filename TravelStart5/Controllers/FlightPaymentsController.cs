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
    public class FlightPaymentsController : ApiController
    {
        private EntitiesFlightPayment db = new EntitiesFlightPayment();

        // GET: api/FlightPayments
        public IQueryable<FlightPayment> GetFlightPayments()
        {
            return db.FlightPayments;
        }

        // GET: api/FlightPayments/5
        [ResponseType(typeof(FlightPayment))]
        public IHttpActionResult GetFlightPayment(int id)
        {
            FlightPayment flightPayment = db.FlightPayments.Find(id);
            if (flightPayment == null)
            {
                return NotFound();
            }

            return Ok(flightPayment);
        }

        // PUT: api/FlightPayments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFlightPayment(int id, FlightPayment flightPayment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != flightPayment.paymentID)
            {
                return BadRequest();
            }

            db.Entry(flightPayment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightPaymentExists(id))
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

        // POST: api/FlightPayments
        [AllowAnonymous]
        [ResponseType(typeof(FlightPayment))]
        public IHttpActionResult PostFlightPayment(FlightPayment flightPayment)
        {
         

            db.FlightPayments.Add(flightPayment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = flightPayment.paymentID }, flightPayment);
        }

        // DELETE: api/FlightPayments/5
        [ResponseType(typeof(FlightPayment))]
        public IHttpActionResult DeleteFlightPayment(int id)
        {
            FlightPayment flightPayment = db.FlightPayments.Find(id);
            if (flightPayment == null)
            {
                return NotFound();
            }

            db.FlightPayments.Remove(flightPayment);
            db.SaveChanges();

            return Ok(flightPayment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FlightPaymentExists(int id)
        {
            return db.FlightPayments.Count(e => e.paymentID == id) > 0;
        }
    }
}