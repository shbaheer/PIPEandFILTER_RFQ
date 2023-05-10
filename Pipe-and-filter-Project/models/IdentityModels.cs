using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Pipe_and_filte.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
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
        public DbSet<Pipe_and_filte.Models.filed>filed { get; set; }
        public DbSet<Pipe_and_filte.Models.RFQ>RFQ { get; set; }
        public DbSet<Pipe_and_filte.Models.baidingCompany> baidingCompany { get; set; }
        public DbSet<Pipe_and_filte.Models.stefOne> stefOne { get; set; }
        public DbSet<Pipe_and_filte.Models.stepTwo> stepTwo { get; set; }
        public DbSet<Pipe_and_filte.Models.stepthree> stepthree { get; set; }
        public DbSet<Pipe_and_filte.Models.stepfour> stepfour { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}