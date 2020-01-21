using System.Data.Entity;
using System.Linq;
using iTechArt.Repositories;
using iTechArt.SchoolSchedule.DomainModel.Rooms;

namespace iTechArt.SchoolSchedule.Repositories.Repositories
{
    public class ClassroomRepository : Repository<Classroom>
    {
        public ClassroomRepository(DbContext context) : base(context)
        {

        }


        protected override IQueryable<Classroom> GetAllQuery()
        {
            return GetQuery(c => c.Lessons);
        }
    }
}