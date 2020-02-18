using Microsoft.AspNet.Identity.EntityFramework;
using iTechArt.SchoolSchedule.Repositories.IdentityModels;

namespace iTechArt.SchoolSchedule.Repositories.DbContexts
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext() : base("IdentityDb") { }

        public static IdentityContext Create()
        {
            return new IdentityContext();
        }
    }
}