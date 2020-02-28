using Microsoft.AspNet.Identity;

namespace iTechArt.SchoolSchedule.Repositories.IdentityModels.ApplicationManagers
{
    public class SchoolScheduleUserManager : UserManager<SchoolScheduleUser>
    {
        public SchoolScheduleUserManager(IUserStore<SchoolScheduleUser> store)
            : base(store)
        {

        }
    }
}