using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace iTechArt.SchoolSchedule.Foundation.Interfaces
{
    public interface ISchoolScheduleUserStore<TUser> : IUserStore<TUser> where TUser : IdentityUser
    { 

    }
}