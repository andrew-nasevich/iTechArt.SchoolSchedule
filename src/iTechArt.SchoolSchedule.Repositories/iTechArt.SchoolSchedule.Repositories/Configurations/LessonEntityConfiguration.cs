using System.Data.Entity.ModelConfiguration;
using iTechArt.SchoolSchedule.DomainModel.Lessons;

namespace iTechArt.SchoolSchedule.Repositories.Configurations
{
    public class LessonEntityConfiguration : EntityTypeConfiguration<Lesson>
    {
        public LessonEntityConfiguration()
        {
            HasRequired(l => l.Teacher).WithMany(t => t.Lessons).HasForeignKey(l => l.TeacherId);
            HasRequired(l => l.Grade).WithMany(g => g.Lessons).HasForeignKey(l => l.GradeId);
            HasOptional(l => l.Group).WithMany(g => g.Lessons).HasForeignKey(l => l.GroupId);
            HasRequired(l => l.Classroom);
        }
    }
}