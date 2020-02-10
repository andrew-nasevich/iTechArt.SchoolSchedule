using iTechArt.Repositories.Interfaces;
using iTechArt.SchoolSchedule.Repositories.Interfaces;

namespace iTechArt.SchoolSchedule.Repositories.SchoolScheduleUnitOfWorks
{
    public class SchoolScheduleUnitOfWorkFactory : ISchoolScheduleUnitOfWorkFactory
    {
        public IUnitOfWork CreateSchoolScheduleUnitOfWork()
        {
            return new SchoolScheduleUnitOfWork();
        }
    }
}