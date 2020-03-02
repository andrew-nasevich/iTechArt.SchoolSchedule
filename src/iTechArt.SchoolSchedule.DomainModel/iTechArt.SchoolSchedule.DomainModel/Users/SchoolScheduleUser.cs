using Microsoft.AspNet.Identity.EntityFramework;

namespace iTechArt.SchoolSchedule.DomainModel.Users
{
    public class SchoolScheduleUser : IdentityUser
    {
        public int PersonId { get; set; }
    }
}