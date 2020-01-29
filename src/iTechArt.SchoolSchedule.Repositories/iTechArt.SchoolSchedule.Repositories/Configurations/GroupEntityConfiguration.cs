using System.Data.Entity.ModelConfiguration;
using iTechArt.SchoolSchedule.DomainModel.Grades;

namespace iTechArt.SchoolSchedule.Repositories.Configurations
{
    public class GroupEntityConfiguration : EntityTypeConfiguration<Group>
    {
        public GroupEntityConfiguration()
        {
            Property(g => g.Name).IsRequired().HasMaxLength(50);
            HasRequired(g => g.Grade).WithMany(g => g.Groups).HasForeignKey(g => g.GradeId).WillCascadeOnDelete(false);
            HasIndex(g => new { g.Name, g.GradeId }).IsUnique();
        }
    }
}