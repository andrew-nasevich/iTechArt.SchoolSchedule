using Microsoft.AspNet.Identity;
using iTechArt.SchoolSchedule.DomainModel.Users;
using iTechArt.SchoolSchedule.Foundation.Interfaces;
using iTechArt.SchoolSchedule.Repositories.Interfaces;

namespace iTechArt.SchoolSchedule.Foundation.SchoolScheduleManagers
{
    public class SchoolScheduleUserManager : UserManager<SchoolScheduleUser>, ISchoolScheduleUserManager
    {
        public SchoolScheduleUserManager(ISchoolScheduleUserStore<SchoolScheduleUser> store)
            : base(store)
        {

        }
    }
}