using System.Data.Entity;
using iTechArt.SchoolSchedule.DomainModel.People;
using iTechArt.SchoolSchedule.Repositories.Configurations;
using iTechArt.SchoolSchedule.Repositories.Migrations;

namespace iTechArt.SchoolSchedule.Repositories.DbContexts
{
    public class SchoolScheduleContext : DbContext
    {
        public SchoolScheduleContext() 
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolScheduleContext, Configuration>());
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ComplexType<Address>();
            modelBuilder.Configurations.Add(new GradeEntityConfiguration());
            modelBuilder.Configurations.Add(new LessonEntityConfiguration());
            modelBuilder.Configurations.Add(new PersonEntityConfiguration());
            modelBuilder.Configurations.Add(new ClassroomEntityConfiguration());
            modelBuilder.Configurations.Add(new CourseEntityConfiguration());
            modelBuilder.Configurations.Add(new GroupEntityConfiguration());
            modelBuilder.Configurations.Add(new HomeworkEntityConfiguration());
            modelBuilder.Configurations.Add(new LessonTimeEntityConfiguration());
            modelBuilder.Configurations.Add(new PupilEntityConfiguration());
            modelBuilder.Configurations.Add(new PupilGroupEntityConfiguration());
        }
    }
}