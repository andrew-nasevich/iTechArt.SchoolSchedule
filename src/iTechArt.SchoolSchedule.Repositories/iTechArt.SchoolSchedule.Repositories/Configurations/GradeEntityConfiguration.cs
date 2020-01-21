using System.Data.Entity.ModelConfiguration;
using iTechArt.SchoolSchedule.DomainModel.Grades;

namespace iTechArt.SchoolSchedule.Repositories.Configurations
{
    public class GradeEntityConfiguration : EntityTypeConfiguration<Grade>
    {
        public GradeEntityConfiguration()
        {
            Property(g => g.Number).IsRequired();
            Property(g => g.Letter).IsOptional();
        }
    }
}