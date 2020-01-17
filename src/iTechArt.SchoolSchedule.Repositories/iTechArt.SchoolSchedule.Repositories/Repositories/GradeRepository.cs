using System.Data.Entity;
using System.Linq;
using iTechArt.Repositories;
using iTechArt.SchoolSchedule.DomainModel.Grades;

namespace iTechArt.SchoolSchedule.Repositories.Repositories
{
    public class GradeRepository : Repository<Grade>
    {
        public GradeRepository(DbContext context) : base(context)
        {

        }


        protected override IQueryable<Grade> GetAllQuery()
        {
            return GetQuery(g => g.Pupils, g => g.Groups, g => g.Lessons);
        }
    }
}