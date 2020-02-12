using System.Data.Entity.ModelConfiguration;
using iTechArt.SchoolSchedule.DomainModel.Lessons;

namespace iTechArt.SchoolSchedule.Repositories.Configurations
{
    public class HomeworkEntityConfiguration : EntityTypeConfiguration<Homework>
    {
        public HomeworkEntityConfiguration()
        {
            Property(h => h.DateTime).IsRequired();
            Property(h => h.Description).IsRequired();
            HasRequired(h => h.Lesson).WithMany(l => l.Homeworks).HasForeignKey(h => h.LessonId);
            HasIndex(h => new { h.DateTime, h.LessonId }).IsUnique();
        }
    }
}