using Microsoft.AspNet.Identity.EntityFramework;

namespace iTechArt.SchoolSchedule.Repositories.IdentityModels
{
    public class ApplicationUser : IdentityUser
    {
        public int Year { get; set; }
    }
}