using System.Data.Entity.ModelConfiguration;
using iTechArt.SchoolSchedule.DomainModel.People;

namespace iTechArt.SchoolSchedule.Repositories.Configurations
{
    public class PersonEntityConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonEntityConfiguration()
        {
            Property(p => p.Name).IsRequired();
            Property(p => p.Surname).IsRequired();
            Property(p => p.Patronymic).IsRequired();
        }
    }
}