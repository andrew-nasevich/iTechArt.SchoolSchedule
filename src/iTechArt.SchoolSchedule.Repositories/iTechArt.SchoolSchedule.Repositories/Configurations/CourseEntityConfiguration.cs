using System.Data.Entity.ModelConfiguration;
using iTechArt.SchoolSchedule.DomainModel.Lessons;

namespace iTechArt.SchoolSchedule.Repositories.Configurations
{
    public class CourseEntityConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseEntityConfiguration()
        {
            Property(c => c.Name).IsRequired().HasMaxLength(50);
            HasIndex(c => c.Name).IsUnique();
        }
    }
}