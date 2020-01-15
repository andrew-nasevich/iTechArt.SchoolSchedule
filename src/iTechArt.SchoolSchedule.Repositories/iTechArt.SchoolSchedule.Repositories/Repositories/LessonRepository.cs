using System.Data.Entity;
using System.Linq;
using iTechArt.Repositories.Repositories;
using iTechArt.SchoolSchedule.DomainModel.Models.Lessons;

namespace iTechArt.SchoolSchedule.Repositories.Repositories
{
    public class LessonRepository : Repository<Lesson>
    {
        public LessonRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public override IQueryable<Lesson> GetFullEntities()
        {
            return ExecuteIncludes(l => l.Teacher, l => l.Grade, l => l.Group, l => l.HomeWork);
        }
    }
}