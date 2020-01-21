using System.Data.Entity;
using System.Linq;
using iTechArt.Repositories;
using iTechArt.SchoolSchedule.DomainModel.Lessons;

namespace iTechArt.SchoolSchedule.Repositories.Repositories
{
    public class LessonRepository : Repository<Lesson>
    {
        public LessonRepository(DbContext context) : base(context)
        {

        }


        protected override IQueryable<Lesson> GetAllQuery()
        {
            return GetQuery(
                l => l.Teacher,
                l => l.Grade, 
                l => l.Group, 
                l => l.Homeworks, 
                l => l.Classroom, 
                l => l.LessonTime,
                l => l.Course);
        }
    }
}