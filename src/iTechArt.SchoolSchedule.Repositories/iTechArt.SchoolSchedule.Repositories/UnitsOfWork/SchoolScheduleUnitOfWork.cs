using System;
using System.Collections.Generic;
using System.Data.Entity;
using iTechArt.Repositories.Interfaces;
using iTechArt.Repositories.UnitsOfWork;


namespace iTechArt.SchoolSchedule.Repositories.UnitsOfWork
{
    public class SchoolScheduleUnitOfWork : UnitOfWork
    {
        public SchoolScheduleUnitOfWork(DbContext dbContext, IDictionary<Type, object> repositories, IRepositoryFactory repositoryFactory)
            : base(dbContext, repositories, repositoryFactory)
        {

        }
    }
}