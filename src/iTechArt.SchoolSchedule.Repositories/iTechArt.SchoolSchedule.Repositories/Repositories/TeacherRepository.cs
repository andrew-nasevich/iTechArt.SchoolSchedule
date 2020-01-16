using System.Data.Entity;
using System.Linq;
using iTechArt.Repositories;
using iTechArt.SchoolSchedule.DomainModel.Models.People;

namespace iTechArt.SchoolSchedule.Repositories.Repositories
{
    public class TeacherRepository : Repository<Teacher>
    {
        public TeacherRepository(DbContext context) : base(context)
        {

        }


        protected override IQueryable<Teacher> GetAllQuery()
        {
            return GetQuery(t => t.Lessons);
        }
    }
}