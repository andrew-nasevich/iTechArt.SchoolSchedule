using System.Data.Entity.ModelConfiguration;
using iTechArt.SchoolSchedule.DomainModel.Grades;

namespace iTechArt.SchoolSchedule.Repositories.Configurations
{
    public class PupilGroupEntityConfiguration : EntityTypeConfiguration<PupilGroup>
    {
        public PupilGroupEntityConfiguration()
        {
            HasKey(pg => new { pg.GroupId, pg.PupilId });
            HasRequired(pg => pg.Pupil).WithMany(p => p.PupilGroups).HasForeignKey(pg => pg.PupilId).WillCascadeOnDelete(false);
            HasRequired(pg => pg.Group).WithMany(g => g.PupilGroups).HasForeignKey(pg => pg.GroupId).WillCascadeOnDelete(false);
        }
    }
}