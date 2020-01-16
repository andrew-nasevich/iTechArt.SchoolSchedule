using System.Data.Entity;
using iTechArt.SchoolSchedule.Repositories.Configurations;

namespace iTechArt.SchoolSchedule.Repositories.DbContexts
{
    public class SchoolScheduleContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new GradeEntityConfiguration());
            modelBuilder.Configurations.Add(new LessonEntityConfiguration());
            modelBuilder.Configurations.Add(new PersonEntityConfiguration());
        }
    }
}