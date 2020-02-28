using Microsoft.AspNet.Identity.EntityFramework;

namespace iTechArt.SchoolSchedule.Repositories.IdentityModels
{
    public class SchoolScheduleUser : IdentityUser
    {
        public int PersonId { get; set; }
    }
}