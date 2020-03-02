using iTechArt.SchoolSchedule.Foundation.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace iTechArt.SchoolSchedule.Foundation.SchoolScheduleStores
{
    public class SchoolScheduleUserStore<TUser> : UserStore<TUser>, ISchoolScheduleUserStore<TUser> where TUser : IdentityUser
    {
        public SchoolScheduleUserStore() 
            : base()
        {

        }

        public SchoolScheduleUserStore(DbContext db)
            : base(db)
        { 

        }
    }
}
