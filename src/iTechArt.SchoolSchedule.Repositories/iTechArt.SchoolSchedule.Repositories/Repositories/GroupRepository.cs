using System.Data.Entity;
using System.Linq;
using iTechArt.Repositories;
using iTechArt.SchoolSchedule.DomainModel.Models.Grades;

namespace iTechArt.SchoolSchedule.Repositories.Repositories
{
    public class GroupRepository : Repository<Group>
    {
        public GroupRepository(DbContext context) : base(context)
        {

        }


        protected override IQueryable<Group> GetAllQuery()
        {
            return GetQuery(g => g.Pupils, g => g.Lessons);
        }
    }
}