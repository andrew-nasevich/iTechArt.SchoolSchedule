using System.Data.Entity.ModelConfiguration;
using iTechArt.SchoolSchedule.DomainModel.Rooms;

namespace iTechArt.SchoolSchedule.Repositories.Configurations
{
    public class ClassroomEntityConfiguration : EntityTypeConfiguration<Classroom>
    {
        public ClassroomEntityConfiguration()
        {
            Property(c => c.RoomName).IsRequired();
            HasIndex(c => c.RoomName).IsUnique();
        }
    }
}