using System;
using System.Collections.Generic;
using iTechArt.Repositories.UnitsOfWork;
using iTechArt.SchoolSchedule.Repositories.DbContexts;
using iTechArt.Repositories.Interfaces;

namespace iTechArt.SchoolSchedule.Repositories.SchoolScheduleUnitOfWork
{
    public class SchoolScheduleUnitOfWork : UnitOfWork
    {
        public SchoolScheduleUnitOfWork(SchoolScheduleContext dbContext, IDictionary<Type, object> repositories, IRepositoryFactory repositoryFactory) 
            : base(dbContext, repositories, repositoryFactory)
        {

        }
    }
}