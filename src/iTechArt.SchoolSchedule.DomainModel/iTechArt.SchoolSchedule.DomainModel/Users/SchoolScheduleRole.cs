using Microsoft.AspNet.Identity.EntityFramework;

namespace iTechArt.SchoolSchedule.Repositories.IdentityModels
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