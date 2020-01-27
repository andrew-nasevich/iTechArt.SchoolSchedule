using System.Data.Entity.ModelConfiguration;
using iTechArt.SchoolSchedule.DomainModel.People;

namespace iTechArt.SchoolSchedule.Repositories.Configurations
{
    public class PersonEntityConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonEntityConfiguration()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(50);
            Property(p => p.Surname).IsRequired().HasMaxLength(50);
            Property(p => p.Patronymic).IsRequired().HasMaxLength(50);
            Property(p => p.Address.Street).IsRequired().HasMaxLength(50);
            Property(p => p.Address.HouseNumber).IsRequired().HasMaxLength(10);
        }
    }
}