using System.Data.Entity.ModelConfiguration;
using iTechArt.SchoolSchedule.DomainModel.People;

namespace iTechArt.SchoolSchedule.Repositories.Configurations
{
    public class PupilEntityConfiguration : EntityTypeConfiguration<Pupil>
    {
        public PupilEntityConfiguration()
        {
            HasRequired(p => p.Grade).WithMany(g => g.Pupils).HasForeignKey(p => p.GradeId);
        }
    }
}