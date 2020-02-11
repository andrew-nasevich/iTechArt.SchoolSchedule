using iTechArt.Repositories.Interfaces;
using iTechArt.SchoolSchedule.Repositories.DbContexts;
using iTechArt.SchoolSchedule.Repositories.Interfaces;

namespace iTechArt.SchoolSchedule.Repositories.SchoolScheduleUnitOfWorks
{
    public class SchoolScheduleUnitOfWorkFactory : ISchoolScheduleUnitOfWorkFactory
    {
        public IUnitOfWork CreateSchoolScheduleUnitOfWork()
        {
            var context = new SchoolScheduleContext();

            return new SchoolScheduleUnitOfWork(context);
        }
    }
}