using Microsoft.AspNet.Identity.EntityFramework;

namespace iTechArt.SchoolSchedule.DomainModel.Users
{
    public class SchoolScheduleRole : IdentityRole
    {
        public SchoolScheduleRole() 
            : base()
        {
            
        }

        public SchoolScheduleRole(string name)
            : base(name)
        {
            
        }
    }
}