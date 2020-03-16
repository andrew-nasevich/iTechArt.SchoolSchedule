using Microsoft.AspNet.Identity.EntityFramework;
using iTechArt.SchoolSchedule.DomainModel.Users;
using iTechArt.SchoolSchedule.Repositories.DbContexts;
using iTechArt.SchoolSchedule.Repositories.Interfaces;

namespace iTechArt.SchoolSchedule.Repositories.SchoolScheduleStores
{
    public class SchoolScheduleUserStore<TRole> : UserStore<TRole>, ISchoolScheduleUserStore<TRole> where TRole : SchoolScheduleUser
    {
        public SchoolScheduleUserStore() 
            : base()
        {

        }

        public SchoolScheduleUserStore(SchoolScheduleAuthenticationContext db)
            : base(db)
        { 

        }
    }
}