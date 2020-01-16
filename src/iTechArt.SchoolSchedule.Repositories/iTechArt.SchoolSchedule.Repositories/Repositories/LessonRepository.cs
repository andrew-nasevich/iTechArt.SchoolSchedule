using System.Data.Entity;
using System.Linq;
using iTechArt.Repositories;
using iTechArt.SchoolSchedule.DomainModel.Models.Lessons;

namespace iTechArt.SchoolSchedule.Repositories.Repositories
{
    public class LessonRepository : Repository<Lesson>
    {
        public LessonRepository(DbContext dbContext) : base(dbContext)
        {

        }


        protected override IQueryable<Lesson> GetAllQuery()
        {
            return GetQuery(l => l.Teacher, l => l.Grade, l => l.Group, l => l.HomeWork);
        }
    }
}