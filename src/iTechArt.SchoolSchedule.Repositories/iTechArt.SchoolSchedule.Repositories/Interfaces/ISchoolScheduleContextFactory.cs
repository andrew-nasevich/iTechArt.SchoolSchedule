using iTechArt.SchoolSchedule.Repositories.DbContexts;

namespace iTechArt.SchoolSchedule.Repositories.Interfaces
{
    public interface ISchoolScheduleContextFactory
    {
        SchoolScheduleContext CreateSchoolScheduleContext();
    }
}