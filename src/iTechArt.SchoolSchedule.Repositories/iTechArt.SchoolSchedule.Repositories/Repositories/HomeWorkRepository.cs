using System.Data.Entity;
using System.Linq;
using iTechArt.Repositories;
using iTechArt.SchoolSchedule.DomainModel.Models.Lessons;

namespace iTechArt.SchoolSchedule.Repositories.Repositories
{
    public class HomeWorkRepository : Repository<HomeWork>
    {
        public HomeWorkRepository(DbContext context) : base(context)
        {

        }


        protected override IQueryable<HomeWork> GetAllQuery()
        {
            return GetQuery(h => h.Lesson);
        }
    }
}