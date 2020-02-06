using iTechArt.SchoolSchedule.Repositories.DbContexts;
using iTechArt.SchoolSchedule.Repositories.Interfaces;

namespace iTechArt.SchoolSchedule.Repositories.SchoolScheduleUnitOfWorks
{
    public class SchoolScheduleUnitOfWorkFactory : ISchoolScheduleUnitOfWorkFactory
    {
        public SchoolScheduleUnitOfWork CreateSchoolScheduleUnitOfWork(SchoolScheduleContext context)
        {
            return new SchoolScheduleUnitOfWork(context);
        }
    }
}