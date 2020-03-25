using Microsoft.AspNet.Identity.EntityFramework;
using iTechArt.SchoolSchedule.DomainModel.Users;
using iTechArt.SchoolSchedule.Repositories.DbContexts;
using iTechArt.SchoolSchedule.Repositories.Interfaces;

namespace iTechArt.SchoolSchedule.Repositories.SchoolScheduleStores
{
    public class SchoolScheduleRoleStore<TRole> : RoleStore<TRole>, ISchoolScheduleRoleStore<TRole> where TRole : SchoolScheduleRole, new()
    {
        public SchoolScheduleRoleStore()
            : base()
        {

        }

        public SchoolScheduleRoleStore(SchoolScheduleAuthenticationContext db)
            : base(db)
        {

        }
    }
}