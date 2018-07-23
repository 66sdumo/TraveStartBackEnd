using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace TravelStart5.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
       
        public string Lname { get; set; }
        public string Fname { get; set; }
        public string Title { get; set; }
        public string Password { get; set; }
      
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
        
        
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
                base.OnModelCreating(modelBuilder);
                //asp net =>user
                modelBuilder.Entity<ApplicationUser>()
                .ToTable("User");
                //aspnetRoles => Role
                modelBuilder.Entity<IdentityRole>()
                    .ToTable("Role");
                //aspnetUserRoles => UserRole
                modelBuilder.Entity<IdentityUserRole>()
                    .ToTable("UserRole");
                //aspnet Claims => UserClaims
                modelBuilder.Entity<IdentityUserClaim>()
                    .ToTable("UserClaim");
                //aspnetuserlogins => user login

                modelBuilder.Entity<IdentityUserLogin>()
            .ToTable("UserLogin");
            }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}