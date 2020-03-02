using Microsoft.AspNet.Identity.EntityFramework;
using iTechArt.SchoolSchedule.DomainModel.Users;

namespace iTechArt.SchoolSchedule.Repositories.DbContexts
{
    public class SchoolScheduleAuthenticationContext : IdentityDbContext<SchoolScheduleUser>
    {
        public SchoolScheduleAuthenticationContext()
            : base("SchoolScheduleAuthentication")
        {

        }


        public static SchoolScheduleAuthenticationContext Create()
        {
            return new SchoolScheduleAuthenticationContext();
        }
    }
}