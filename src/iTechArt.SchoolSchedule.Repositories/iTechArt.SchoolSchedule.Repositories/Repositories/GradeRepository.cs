using System.Data.Entity;
using System.Linq;
using iTechArt.Repositories;
using iTechArt.SchoolSchedule.DomainModel.Models.Grades;

namespace iTechArt.SchoolSchedule.Repositories.Repositories
{
    public class GradeRepository : Repository<Grade>
    {
        public GradeRepository(DbContext dbContext) : base(dbContext)
        {

        }


        protected override IQueryable<Grade> GetAllQuery()
        {
            return GetQuery(g => g.Pupils, g => g.Groups, g => g.Lessons);
        }
    }
}