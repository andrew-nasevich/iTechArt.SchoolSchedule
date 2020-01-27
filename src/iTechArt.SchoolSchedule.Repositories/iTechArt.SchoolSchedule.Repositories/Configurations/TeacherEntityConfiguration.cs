using System.Data.Entity.ModelConfiguration;
using iTechArt.SchoolSchedule.DomainModel.People;

namespace iTechArt.SchoolSchedule.Repositories.Configurations
{
    public class TeacherEntityConfiguration : EntityTypeConfiguration<Teacher>
    {
        public TeacherEntityConfiguration()
        {
            ToTable("Teachers");
        }
    }
}