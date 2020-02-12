using System.Data.Entity.ModelConfiguration;
using iTechArt.SchoolSchedule.DomainModel.Lessons;

namespace iTechArt.SchoolSchedule.Repositories.Configurations
{
    public class LessonTimeEntityConfiguration : EntityTypeConfiguration<LessonTime>
    {
        public LessonTimeEntityConfiguration()
        {
            Property(lt => lt.DayOfWeek).IsRequired();
            Property(lt => lt.Order).IsRequired();
            HasIndex(lt => new { lt.DayOfWeek, lt.Order }).IsUnique();
        }
    }
}