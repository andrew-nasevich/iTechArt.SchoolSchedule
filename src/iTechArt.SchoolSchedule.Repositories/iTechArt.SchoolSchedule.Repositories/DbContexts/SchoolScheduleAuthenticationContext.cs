using Microsoft.AspNet.Identity.EntityFramework;
using iTechArt.SchoolSchedule.Repositories.IdentityModels;

namespace iTechArt.SchoolSchedule.Repositories.DbContexts
{
    public class SchoolScheduleAuthenticationContext : IdentityDbContext<SchoolScheduleUser>
    {
        public SchoolScheduleAuthenticationContext()
            : base("IdentityDb")
        {

        }


        public static SchoolScheduleAuthenticationContext Create()
        {
            return new SchoolScheduleAuthenticationContext();
        }
    }
}