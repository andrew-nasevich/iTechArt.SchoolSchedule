using Microsoft.AspNet.Identity.EntityFramework;

namespace iTechArt.SchoolSchedule.Repositories.IdentityModels
{
    public class AppRole : IdentityRole
    {
        public AppRole() 
            : base()
        {
            
        }

        public AppRole(string name)
            : base(name)
        {
            
        }
    }
}