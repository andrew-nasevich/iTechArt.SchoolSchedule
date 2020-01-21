using System.Data.Entity;
using System.Linq;
using iTechArt.Repositories;
using iTechArt.SchoolSchedule.DomainModel.Grades;

namespace iTechArt.SchoolSchedule.Repositories.Repositories
{
    public class PupilGroupRepository : Repository<PupilGroup>
    {
        public PupilGroupRepository(DbContext context) : base(context)
        {

        }


        protected override IQueryable<PupilGroup> GetAllQuery()
        {
            return GetQuery(g => g.Pupil, g => g.Group);
        }
    }
}