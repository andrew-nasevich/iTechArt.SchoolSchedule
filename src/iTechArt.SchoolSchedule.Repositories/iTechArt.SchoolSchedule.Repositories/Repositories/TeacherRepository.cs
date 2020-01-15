using System.Data.Entity;
using System.Linq;
using iTechArt.Repositories.Repositories;
using iTechArt.SchoolSchedule.DomainModel.Models.People;

namespace iTechArt.SchoolSchedule.Repositories.Repositories
{
    public class TeacherRepository : Repository<Teacher>
    {
        public TeacherRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public override IQueryable<Teacher> GetFullEntities()
        {
            return ExecuteIncludes(t => t.Lessons);
        }
    }
}