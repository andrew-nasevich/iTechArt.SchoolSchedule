using iTechArt.SchoolSchedule.Repositories.Interfaces;

namespace iTechArt.SchoolSchedule.Repositories.DbContexts
{
    public class SchoolScheduleContextFactory : ISchoolScheduleContextFactory
    {
        public SchoolScheduleContext CreateSchoolScheduleContext()
        {
            return new SchoolScheduleContext();
        }
    }
}