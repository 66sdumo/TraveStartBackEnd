using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TravelStart5.Controllers
{
    public class SeatController : ApiController
    {
        public static bool[] seats;
        public static int totAssignLeft;
        public static int totAssignRight;
        public static int totAssignMiddle;
        // GET: api/Seat
        [AllowAnonymous]
        public string GetSeat(string[] args, int sideNo )
        {
           
           
            seats = new bool[51];
            int selectedSide = 0;

           

                for (int i = 0; i <= 50; i++)

                    seats[i] = false;

                for (int i = 1; i <= 50; i++)
                {

                    selectedSide = sideNo;

                    while (selectedSide < 1 || selectedSide > 3)
                    {

                        selectedSide = sideNo;
                        return  "error for wrong number";

                    }

                    if (selectedSide == 1)
                    {

                        if (totAssignLeft == 10)
                        {

                            return  "left side full";

                        }

                        else if (totAssignLeft < 10)
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

                            return ("A"+ index.ToString());

                        }

                    }

                    if (selectedSide == 2)
                    {

                        if (totAssignMiddle == 30)
                        {
                            return  "Middle side full";
                        }

                        else if (totAssignMiddle < 30)
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

                            return "B"+index.ToString();

                        }

                    }



                    if (selectedSide == 3)
                    {

                        if (totAssignRight == 10)
                        {
                            return  "Right side full";
                        }

                        else if (totAssignRight < 10)
                        {



                            bool noDuplicate = false;
                            Random rand = new Random();
                            int index = 0;

                            while (!noDuplicate)
                            {
                                noDuplicate = true;
                                index = rand.Next(41, 51);
                                if (seats[index] == true)
                                    noDuplicate = false;
                            }
                            seats[index] = true;
                            totAssignRight++;

                            return "C"+index.ToString();


                        }

                    }

                }

                return  "All Seats are full";

            
        }




        // GET: api/Seat/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Seat
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Seat/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Seat/5
        public void Delete(int id)
        {
        }
    }
}




/*Seat allocation dump
 * 
 * 
 * 
        [AllowAnonymous]
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
         //   Console.WriteLine("seat no :", index);
            return index;
        }

        [AllowAnonymous]
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
           // Console.WriteLine("seat no :", index);
            return index;
        }


        [AllowAnonymous]
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
          //  Console.WriteLine("seat no :", index);
            return index;
        }
 * 
 * 
 *  */
