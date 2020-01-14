using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArt.Repositories.UnitsOfWork;

namespace iTechArt.SchoolSchedule.Repositories.SchoolScheduleUnitOfWork
{
    public class SchoolScheduleUnitOfWork : UnitOfWork
    {
        public SchoolScheduleUnitOfWork(DbContext dbContext, IDictionary<Type, object> repositories) 
            : base(dbContext, repositories)
        {

        }
    }
}