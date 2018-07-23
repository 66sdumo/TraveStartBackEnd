using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using TravelStart5.Models;

namespace TravelStart5.Controllers
{
    public class AccntController : ApiController
    {

        [Route("api/User/Register")]
        [HttpPost]
        [AllowAnonymous]

        public IdentityResult Register(AccountModel model)
        {
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            var user = new ApplicationUser() {UserName =model.Username, Email = model.Email };
            user.Lname = model.Lname;
            user.Fname = model.Fname;
            user.Title = model.Title;
            user.Password = model.Password;
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 3
            };
            IdentityResult result = manager.Create(user, model.Password);
            manager.AddToRoles(user.Id, model.Roles);
            return result;
        }

        [HttpGet]
        [Route("api/GetUserClaims")]
        [AllowAnonymous]

        public AccountModel GetUserClaims()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            AccountModel model = new AccountModel()
            {
                Username = identityClaims.FindFirst("Username").Value,
                Lname = identityClaims.FindFirst("Lname").Value,
                Fname = identityClaims.FindFirst("Fname").Value,
                Title = identityClaims.FindFirst("Title").Value,
                Email = identityClaims.FindFirst("Email").Value
            };
            return model;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("api/ForAdminRole")]

        public string ForAdminRole()
        {
            return "for admin role";
        }

        [HttpGet]
        [Authorize(Roles = "Reader")]
        [Route("api/ForReaderRole")]

        public string ForReaderRole()
        {
            return "for reader role";
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        [Route("api/ForUserRole")]

        public string ForUserRole()
        {
            return "for user role";
        }


        [Route("api/User/put")]
        [HttpPut]
        [AllowAnonymous]
        public void Put(string Uname, [FromBody]AccountModel acount)
        {
            using (ApplicationDbContext entities = new ApplicationDbContext())
            {
                var entity = entities.Users.FirstOrDefault(x => x.UserName == Uname);

                entity.Fname = acount.Fname;
                entity.Lname = acount.Lname;
                entity.Title = acount.Title;
                entity.Email = acount.Email;

                entities.SaveChanges();
            }
        }

        
    }
}
