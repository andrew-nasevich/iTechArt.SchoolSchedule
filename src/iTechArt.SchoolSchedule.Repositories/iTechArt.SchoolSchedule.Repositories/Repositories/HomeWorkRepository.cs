using System.Data.Entity;
using System.Linq;
using iTechArt.Repositories;
using iTechArt.SchoolSchedule.DomainModel.Lessons;

namespace iTechArt.SchoolSchedule.Repositories.Repositories
{
    public class HomeworkRepository : Repository<Homework>
    {
        public HomeworkRepository(DbContext context) : base(context)
        {

        }


        protected override IQueryable<Homework> GetAllQuery()
        {
            return GetQuery(h => h.Lesson);
        }
    }
}