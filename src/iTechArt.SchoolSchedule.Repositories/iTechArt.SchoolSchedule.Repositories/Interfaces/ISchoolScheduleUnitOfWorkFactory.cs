using iTechArt.Repositories.Interfaces;

namespace iTechArt.SchoolSchedule.Repositories.Interfaces
{
    public interface ISchoolScheduleUnitOfWorkFactory
    {
        IUnitOfWork CreateSchoolScheduleUnitOfWork();
    }
}