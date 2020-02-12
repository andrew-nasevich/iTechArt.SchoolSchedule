namespace iTechArt.SchoolSchedule.DomainModel.People
{
    public class Person : Entity
    {
        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public Address Address { get; set; }
    }
}