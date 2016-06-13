using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SoccerTrainingManager.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
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

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<SoccerTrainingManager.Models.Roster> Rosters { get; set; }

        public System.Data.Entity.DbSet<SoccerTrainingManager.Models.TrainingSession> TrainingSessions { get; set; }

        public System.Data.Entity.DbSet<SoccerTrainingManager.Models.WarmUp> WarmUps { get; set; }

        public System.Data.Entity.DbSet<SoccerTrainingManager.Models.TechnicalDrill> TechnicalDrills { get; set; }

        public System.Data.Entity.DbSet<SoccerTrainingManager.Models.PossessionDrill> PossessionDrills { get; set; }

        public System.Data.Entity.DbSet<SoccerTrainingManager.Models.ShootingDrill> ShootingDrills { get; set; }

        public System.Data.Entity.DbSet<SoccerTrainingManager.Models.Fitness> Fitnesses { get; set; }

        public System.Data.Entity.DbSet<SoccerTrainingManager.Models.Rating> Ratings { get; set; }
    }
}