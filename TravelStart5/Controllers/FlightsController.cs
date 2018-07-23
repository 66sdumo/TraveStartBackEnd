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
    public class FlightsController : ApiController
    {
        private TravelStart2DB db = new TravelStart2DB();

        // GET: api/Flights
         [AllowAnonymous]
          public IQueryable<Flight> GetFlights()
          {
              return db.Flights;
          }

        /* 
          [AllowAnonymous]
          public IQueryable<Flight> GetFlights(string dept)
          {
              var flight = db.Flights.Where(x => x.Airport == dept);
              if (flight == null)
              {
                  return null;
              }
              return flight;
          }

          [AllowAnonymous]
          public IQueryable<Flight> GetRetFlights(string rturn)
          {
              var flight = db.Flights.Where(x => x.Airport == rturn);
              if (flight == null)
              {
                  return null;
              }
              return flight;
          }


        

          [AllowAnonymous]
          public IQueryable<Flight> GetDate(string date)
          {
              var Fdate = db.Flights.Where(x => x.Date == date);
              if (Fdate == null)
              {
                  return null;
              }
              return Fdate;
          }

      */


        public static bool[] seats;
        public static int totAssignLeft;
        public static int totAssignRight;
        public static int totAssignMiddle;


        static void Main(string[] args,int sideNo)
        {
            seats = new bool[50];
            int selectedSide = 0;

            for (int i = 0; i <=50; i ++)
            {
                seats[i] = false;

                for ( int y = 1;y <= 50; y++)
                {
                    Console.WriteLine("type 1 2 or 3 ");
                    selectedSide = sideNo;

                    while (selectedSide<1  || selectedSide >3)
                    {
                        Console.WriteLine("error for wrong number");
                        selectedSide = sideNo;

                    }

                    if(selectedSide == 1 )
                    {

                        if (totAssignLeft == 10)//totAssignMiddle < 30 && totAssignRight < 10
                        {
                            Console.WriteLine("left side full");
                        }

                        else if (totAssignLeft < 10)
                        {
                            assignToLeft();

 
                        }
                    }

                   else if (selectedSide == 2)
                    {

                        if (totAssignMiddle == 30)//totAssignMiddle < 30 && totAssignRight < 10
                        {
                            Console.WriteLine("left side full");
                        }

                        else if (totAssignMiddle < 30)
                        {
                            assignToMiddle();
                        }
                    }

                   else if (selectedSide == 3)
                    {

                        if (totAssignRight == 10)//totAssignMiddle < 30 && totAssignRight < 10
                        {
                            Console.WriteLine("left side full");
                        }

                        else if (totAssignRight < 10)
                        {
                            assignToRight();


                        }
                    }
                }
            }

        }

        public static int assignToLeft()
        {
            bool noDuplicate = false;
            Random rand = new Random();
            int index = 0;

            //keep generating the seat number until a FREE seat is assigned
            while (!noDuplicate)
            {
                noDuplicate = true;
                index = rand.Next(1, 11);
                if (seats[index] == true)
                    noDuplicate = false;
            }
            seats[index] = true;
            totAssignLeft++;
            Console.WriteLine("seat no :",index);
            return index;
        }


        public static int assignToMiddle()
        {
            bool noDuplicate = false;
            Random rand = new Random();
            int index = 0;

            while (!noDuplicate)
            {
                noDuplicate = true;
                index = rand.Next(11, 41);
                if (seats[index] == true)
                    noDuplicate = false;
            }
            seats[index] = true;
            totAssignMiddle++;
            Console.WriteLine("seat no :", index);
            return index;
        }



        public static int assignToRight()
        {
            bool noDuplicate = false;
            Random rand = new Random();
            int index = 0;

            while (!noDuplicate)
            {
                noDuplicate = true;
                index = rand.Next(11, 41);
                if (seats[index] == true)
                    noDuplicate = false;
            }
            seats[index] = true;
            totAssignRight++;
            Console.WriteLine("seat no :", index);
            return index;
        }





        [AllowAnonymous]

        public IQueryable<Flight> GetFlight(string dept,string deptDAte)
        {
            var user = db.Flights.Where(x => x.Airport == dept && x.Date == deptDAte);

            if (user == null)
            {
                return null;
            }
            return user;
        }

        [AllowAnonymous]

        public IQueryable<Flight> GetRetFlight(string rturn, string rturnDate)
        {
            var user = db.Flights.Where(x => x.Airport == rturn && x.Date == rturnDate);

            if (user == null)
            {
                return null;
            }
            return user;
        }


        // GET: api/Flights/5
        [ResponseType(typeof(Flight))]
        public IHttpActionResult GetFlight(int id)
        {
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return NotFound();
            }

            return Ok(flight);
        }

        // PUT: api/Flights/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFlight(int id, Flight flight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != flight.FlightId)
            {
                return BadRequest();
            }

            db.Entry(flight).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightExists(id))
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

        // POST: api/Flights
        [AllowAnonymous]
        [ResponseType(typeof(Flight))]
        public IHttpActionResult PostFlight(Flight flight)
        {

            db.Flights.Add(flight);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = flight.FlightId }, flight);
        }

        // DELETE: api/Flights/5
        [ResponseType(typeof(Flight))]
        public IHttpActionResult DeleteFlight(int id)
        {
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return NotFound();
            }

            db.Flights.Remove(flight);
            db.SaveChanges();

            return Ok(flight);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FlightExists(int id)
        {
            return db.Flights.Count(e => e.FlightId == id) > 0;
        }
    }

 
}