using iTechArt.SchoolSchedule.Foundation.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace iTechArt.SchoolSchedule.Foundation.SchoolScheduleStores
{
    public class SchoolScheduleRoleStore<TRole> : RoleStore<TRole>, ISchoolScheduleRoleStore<TRole> where TRole : IdentityRole, new()
    {
        public SchoolScheduleRoleStore()
            : base()
        {

        }

        public SchoolScheduleRoleStore(DbContext db)
            : base(db)
        {

        }
    }
}