using System;
using System.Collections.Generic;
using iTechArt.Repositories.UnitsOfWork;
using iTechArt.SchoolSchedule.Repositories.DbContexts;

namespace iTechArt.SchoolSchedule.Repositories.SchoolScheduleUnitOfWork
{
    public class SchoolScheduleUnitOfWork : UnitOfWork
    {
        public SchoolScheduleUnitOfWork(SchoolScheduleContext dbContext, IDictionary<Type, object> repositories) 
            : base(dbContext, repositories)
        {

        }
    }
}