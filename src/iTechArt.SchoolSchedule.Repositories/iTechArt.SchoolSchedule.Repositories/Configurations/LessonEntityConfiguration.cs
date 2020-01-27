using System.Data.Entity.ModelConfiguration;
using iTechArt.SchoolSchedule.DomainModel.Lessons;

namespace iTechArt.SchoolSchedule.Repositories.Configurations
{
    public class LessonEntityConfiguration : EntityTypeConfiguration<Lesson>
    {
        public LessonEntityConfiguration()
        {
            HasRequired(l => l.Teacher).WithMany(t => t.Lessons).HasForeignKey(l => l.TeacherId).WillCascadeOnDelete(false);
            HasRequired(l => l.Grade).WithMany(g => g.Lessons).HasForeignKey(l => l.GradeId).WillCascadeOnDelete(false);
            HasOptional(l => l.Group).WithMany(g => g.Lessons).HasForeignKey(l => l.GroupId).WillCascadeOnDelete(false);
            HasRequired(l => l.Classroom).WithMany(c => c.Lessons).HasForeignKey(l => l.ClassroomId).WillCascadeOnDelete(false);
            HasRequired(l => l.LessonTime).WithMany(lt => lt.Lessons).HasForeignKey(l => l.LessonTimeId).WillCascadeOnDelete(false);
            HasRequired(l => l.Course).WithMany(c => c.Lessons).HasForeignKey(l => l.CourseId).WillCascadeOnDelete(false);
            HasIndex(l => new { l.ClassroomId, l.LessonTimeId, l.TeacherId}).IsUnique();
        }
    }
}