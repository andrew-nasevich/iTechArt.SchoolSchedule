using Microsoft.AspNet.Identity;
using iTechArt.SchoolSchedule.DomainModel.Users;

namespace iTechArt.SchoolSchedule.Repositories.Interfaces
{
    public interface ISchoolScheduleRoleStore<TRole> : IRoleStore<TRole, string> where TRole : SchoolScheduleRole
    {

    }
}