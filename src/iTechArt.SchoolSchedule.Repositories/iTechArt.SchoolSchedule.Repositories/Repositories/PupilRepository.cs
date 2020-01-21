using System.Data.Entity;
using System.Linq;
using iTechArt.Repositories;
using iTechArt.SchoolSchedule.DomainModel.People;

namespace iTechArt.SchoolSchedule.Repositories.Repositories
{
    public class PupilRepository : Repository<Pupil>
    {
        public PupilRepository(DbContext context) : base(context)
        {

        }


        protected override IQueryable<Pupil> GetAllQuery()
        {
            return GetQuery(p => p.Grade, p => p.PupilGroups);
        }
    }
}