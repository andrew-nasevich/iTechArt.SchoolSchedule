using System.Data.Entity;
using System.Linq;
using iTechArt.Repositories.Repositories;
using iTechArt.SchoolSchedule.DomainModel.Models.People;

namespace iTechArt.SchoolSchedule.Repositories.Repositories
{
    public class PupilRepository : Repository<Pupil>
    {
        public PupilRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public override IQueryable<Pupil> GetFullEntities()
        {
            return ExecuteIncludes(p => p.Grade, p => p.Group);
        }
    }
}