using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelStart5.Models
{
    public class AccountModel
    {
       
        public string Username { get; set; }
        public string Lname { get; set; }
        public string Fname { get; set; }
        public string Title { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public string[] Roles { get; set;  }


    }
}