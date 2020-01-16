using System;
using System.Collections.Generic;
using System.Data.Entity;
using iTechArt.Repositories.Interfaces;
using iTechArt.Repositories;
using iTechArt.SchoolSchedule.DomainModel.Models.Grades;
using iTechArt.SchoolSchedule.DomainModel.Models.Lessons;
using iTechArt.SchoolSchedule.DomainModel.Models.People;
using iTechArt.SchoolSchedule.Repositories.Repositories;

namespace iTechArt.SchoolSchedule.Repositories.UnitsOfWork
{
    public class SchoolScheduleUnitOfWork : UnitOfWork
    {
        private readonly IDictionary<Type, Type> _repositoriesMapping;

        public SchoolScheduleUnitOfWork(DbContext dbContext)
            : base(dbContext)
        {
            _repositoriesMapping = new Dictionary<Type, Type>()
            {
                {typeof(Grade), typeof(GradeRepository) },
                {typeof(Group), typeof(GroupRepository) },
                {typeof(HomeWork), typeof(HomeWorkRepository) },
                {typeof(Lesson), typeof(LessonRepository) },
                {typeof(Pupil), typeof(PupilRepository) },
                {typeof(Teacher), typeof(TeacherRepository) }
            };

        }


        protected override IRepository<T> CreateRepository<T>()
        {
            if (_repositoriesMapping.TryGetValue(typeof(T), out var repositoryType))
            {
                return (IRepository<T>)Activator.CreateInstance(repositoryType, _dbContext);
            }

            return base.CreateRepository<T>();
        }
    }
}