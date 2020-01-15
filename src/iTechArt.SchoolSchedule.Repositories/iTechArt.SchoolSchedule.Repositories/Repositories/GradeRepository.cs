using System.Data.Entity;
using System.Linq;
using iTechArt.Repositories.Repositories;
using iTechArt.SchoolSchedule.DomainModel.Models.Grades;

namespace iTechArt.SchoolSchedule.Repositories.Repositories
{
    public class GradeRepository : Repository<Grade>
    {
        public GradeRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public override IQueryable<Grade> GetFullEntities()
        {
            return ExecuteIncludes(g => g.Pupils, g => g.Groups, g => g.Lessons);
        }
    }
}