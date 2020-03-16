using Microsoft.AspNet.Identity;
using iTechArt.SchoolSchedule.DomainModel.Users;
using iTechArt.SchoolSchedule.Foundation.Interfaces;
using iTechArt.SchoolSchedule.Repositories.Interfaces;

namespace iTechArt.SchoolSchedule.Foundation.SchoolScheduleManagers
{
    public class SchoolScheduleRoleManager : RoleManager<SchoolScheduleRole>, ISchoolScheduleRoleManager
    {
        public SchoolScheduleRoleManager(ISchoolScheduleRoleStore<SchoolScheduleRole> store)
            : base(store)
        {
        
        }
    }
}