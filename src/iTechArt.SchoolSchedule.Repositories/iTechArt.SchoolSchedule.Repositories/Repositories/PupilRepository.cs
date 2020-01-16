using System.Data.Entity;
using System.Linq;
using iTechArt.Repositories;
using iTechArt.SchoolSchedule.DomainModel.Models.People;

namespace iTechArt.SchoolSchedule.Repositories.Repositories
{
    public class PupilRepository : Repository<Pupil>
    {
        public PupilRepository(DbContext dbContext) : base(dbContext)
        {

        }


        protected override IQueryable<Pupil> GetAllQuery()
        {
            return GetQuery(p => p.Grade);
        }
    }
}