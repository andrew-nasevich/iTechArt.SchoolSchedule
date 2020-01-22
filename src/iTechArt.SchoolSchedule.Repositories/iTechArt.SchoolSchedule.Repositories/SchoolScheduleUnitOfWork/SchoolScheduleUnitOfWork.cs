using System;
using System.Collections.Generic;
using System.Data.Entity;
using iTechArt.Repositories.Interfaces;
using iTechArt.Repositories;
using iTechArt.SchoolSchedule.DomainModel.Lessons;
using iTechArt.SchoolSchedule.DomainModel.People;
using iTechArt.SchoolSchedule.Repositories.Repositories;

namespace iTechArt.SchoolSchedule.Repositories.UnitsOfWork
{
    public class SchoolScheduleUnitOfWork : UnitOfWork
    {
        private readonly IDictionary<Type, Type> _repositoriesMapping;


        public SchoolScheduleUnitOfWork(DbContext сontext)
            : base(сontext)
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