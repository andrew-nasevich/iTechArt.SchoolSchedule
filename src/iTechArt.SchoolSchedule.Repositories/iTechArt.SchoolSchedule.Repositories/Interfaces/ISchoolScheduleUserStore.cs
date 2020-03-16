using Microsoft.AspNet.Identity;
using iTechArt.SchoolSchedule.DomainModel.Users;

namespace iTechArt.SchoolSchedule.Repositories.Interfaces
{
    public interface ISchoolScheduleUserStore<TUser> : IUserStore<TUser> where TUser : SchoolScheduleUser
    { 

    }
}