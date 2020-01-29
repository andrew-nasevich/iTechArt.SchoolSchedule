using System;
using System.Collections.Generic;
using System.Data.Entity;
using iTechArt.Repositories;
using iTechArt.Repositories.Interfaces;
using iTechArt.SchoolSchedule.DomainModel.Lessons;
using iTechArt.SchoolSchedule.DomainModel.People;
using iTechArt.SchoolSchedule.Repositories.Repositories;

namespace iTechArt.SchoolSchedule.Repositories.SchoolScheduleUnitOfWork
{
    public class SchoolScheduleUnitOfWork<TContext> : UnitOfWork<TContext> 
        where TContext : DbContext
    {
        private readonly IDictionary<Type, Type> _repositoriesMapping;


        public SchoolScheduleUnitOfWork(TContext context)
            : base(context)
        {
            _repositoriesMapping = new Dictionary<Type, Type>()
            {
                { typeof(Homework), typeof(HomeworkRepository) },
                { typeof(Lesson), typeof(LessonRepository) },
                { typeof(Pupil), typeof(PupilRepository) }
            };
        }


        protected override IRepository<T> CreateRepository<T>()
        {
            if (_repositoriesMapping.TryGetValue(typeof(T), out var repositoryType))
            {
                return (IRepository<T>)Activator.CreateInstance(repositoryType, Context);
            }

            return base.CreateRepository<T>();
        }
    }
}