using System;
using System.Collections.Generic;
using iTechArt.Repositories;
using iTechArt.Repositories.Interfaces;
using iTechArt.SchoolSchedule.DomainModel.Lessons;
using iTechArt.SchoolSchedule.DomainModel.People;
using iTechArt.SchoolSchedule.Repositories.DbContexts;
using iTechArt.SchoolSchedule.Repositories.Repositories;

namespace iTechArt.SchoolSchedule.Repositories.SchoolScheduleUnitOfWorks
{
    public class SchoolScheduleUnitOfWork : UnitOfWork<SchoolScheduleContext>
    {
        private readonly IDictionary<Type, Type> _repositoriesMapping;


        public SchoolScheduleUnitOfWork()
            : base(new SchoolScheduleContext())
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