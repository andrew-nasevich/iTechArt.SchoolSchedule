using System.Data.Entity;
using System.Linq;
using iTechArt.Repositories;
using iTechArt.SchoolSchedule.DomainModel.Grades;

namespace iTechArt.SchoolSchedule.Repositories.Repositories
{
    public class GroupRepository : Repository<Group>
    {
        public GroupRepository(DbContext context) : base(context)
        {

        }


        protected override IQueryable<Group> GetAllQuery()
        {
            return GetQuery(g => g.PupilGroups, g => g.Lessons);
        }
    }
}