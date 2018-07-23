using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TravelStart5.Controllers
{
    public class RefController : ApiController
    {
        // GET: api/Ref
        [AllowAnonymous]
        public string  GetRef()
        {
            char[] letters = "qwertyuiopasdfghjklzxcvbnm1234567890".ToCharArray();
            Random r = new Random();
            string randomString = "";

            for (int i = 0; i < 15; i++)
            {
                randomString += letters[r.Next(0, 35)].ToString();
            }
            return randomString.ToUpper();
        }

    
     
    }
}
