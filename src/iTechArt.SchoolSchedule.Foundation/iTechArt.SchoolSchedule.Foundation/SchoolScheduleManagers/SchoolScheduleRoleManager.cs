using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace iTechArt.SchoolSchedule.Repositories.IdentityModels.ApplicationManagers
{
    public class SchoolScheduleRoleManager : RoleManager<SchoolScheduleRole>, IDisposable
    {
        public SchoolScheduleRoleManager(RoleStore<SchoolScheduleRole> store)
            : base(store)
        {
        
        }
    }
}