using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace iTechArt.SchoolSchedule.Foundation.Interfaces
{
    public interface ISchoolScheduleRoleStore<TRole> : IQueryableRoleStore<TRole>, IQueryableRoleStore<TRole, string>, IRoleStore<TRole, string> where TRole : IdentityRole
    {

    }
}