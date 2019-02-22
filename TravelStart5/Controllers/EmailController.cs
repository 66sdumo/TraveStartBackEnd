using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Mail;
using TravelStart5.Models;
using System.Text.RegularExpressions;

namespace TravelStart5.Controllers
{
    public class EmailController : ApiController
    {
        // GET: api/Email
        [AllowAnonymous]


        public string GetEmail(string TravDetails,string title,string fname,string lname,string email,string Airport,string Airline,string Date,string Time,string class1, string Airport2, string Airline2, string Date2, string Time2, string class2, string Ref )
        {

         

            string[] namesArray =TravDetails.Split(',');
            List<string> namesList = new List<string>(namesArray.Length);
            namesList.AddRange(namesArray);
            namesList.Reverse();

            var testArray = string.Join("\n", namesArray);
            System.Console.WriteLine(testArray);

          

            // This is valid for :Travellers1 :, ,Traveller 1,Ms Seabi Tumi 66sdumo@gmail.com,Traveller 2,Ms Seabi Tumi 66sdumo@gmail.com
            //---------------------------------------------
            //This is valid for :Travellers1 :
            //Traveller 1
            //Ms Seabi Tumi 66sdumo@gmail.com
            //Traveller 2
            //Ms Seabi Tumi 66sdumo@gmail.com
            //------------------------------------------

        


            MailMessage mailMessage = new MailMessage("66sdumo@gmail.com", "66sdumo@gmail.com");
            mailMessage.Subject = "Booking Information";

            mailMessage.Body = "Hi " + title + " " + fname + " " + lname + "\n" +
                "\n" +
                "Thank You for using TravelStart.\n " +
                 "\n" +
                 "Your departure booking has been confirmed as follows : " + "    " + "Your return booking has been confirmed as follows : " +
                 "\n Airport : " + Airport + "                                                      " + " Airport : " + Airport2 +
                 "\n Airline : " + Airline + "                                                                " + " Airline : " + Airline2 +
                 "\n Date : " + Date + "  & Time : " + Time + "                                      " + " Date : " + Date2 + "  & Time : " + Time2 +
                 "\n Class : " + class1 + "                                                                 " + " Class : " + class2 +
                 "\n " +
                 "\nRef no : " + Ref +
                 "\n" +
                 "\nThis booking is valid for :" +
                 testArray;
          
               
         




            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "email",
                Password =  "password"
            };
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);


        

            return "Sent Successfully to :"+email ;

          


        }






            // GET: api/Email/5
        [AllowAnonymous]
        public string Get(int id)
        {
            return "value";
        }

        /* POST: api/Email
        public void Post([FromBody]string value)
        {
        }*/

        // PUT: api/Email/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Email/5
        public void Delete(int id)
        {
        }
    }
}
















/*
   [AllowAnonymous]
public string GetEmail(string title,string fname,string lname,string email,string Airport,string Airline,string Date,string Time,string class1, string Airport2, string Airline2, string Date2, string Time2, string class2)
{ 
    MailMessage mailMessage = new MailMessage("66sdumo@gmail.com", "66sdumo@gmail.com");
    mailMessage.Subject = "Booking Information";
    mailMessage.Body = "Hi " + title + " " + fname + " " + lname + "\n" +
        "\n" +
        "Thank You for using TravelStart.\n " +
         "\n"+
         "Your departure booking has been confirmed as follows : " +
         "\n Airport : " + Airport+
         "\n Airline : " + Airline+
         "\n Date : " + Date + "  & Time : " + Time +
         "\n Class : " + class1
          + "\n" 
          + "\n" 
             + "\n" 
           + "\n" +
        "Your return booking has been confirmed as follows : " +
        "\n Airport : " + Airport2 +
        "\n Airline : " + Airline2 +
        "\n Date : " + Date2 + "  & Time : " + Time2+
        "\n Class : " + class2;





    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

    smtpClient.Credentials = new System.Net.NetworkCredential()
    {
        UserName = "66sdumo@gmail.com",
        Password =  "6653767ZDUmo*"
    };
    smtpClient.EnableSsl = true;
    smtpClient.Send(mailMessage);

    return "Sent Successfully to :"+email;

}*/
