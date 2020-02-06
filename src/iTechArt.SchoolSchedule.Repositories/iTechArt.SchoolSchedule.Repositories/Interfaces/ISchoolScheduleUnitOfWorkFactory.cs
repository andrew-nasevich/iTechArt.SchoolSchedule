using iTechArt.SchoolSchedule.Repositories.DbContexts;
using iTechArt.SchoolSchedule.Repositories.SchoolScheduleUnitOfWorks;

namespace iTechArt.SchoolSchedule.Repositories.Interfaces
{
    public interface ISchoolScheduleUnitOfWorkFactory
    {
        SchoolScheduleUnitOfWork CreateSchoolScheduleUnitOfWork(SchoolScheduleContext context);
    }
}