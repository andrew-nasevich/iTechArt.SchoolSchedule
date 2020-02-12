using System.Collections.Generic;
using iTechArt.SchoolSchedule.DomainModel.Lessons;

namespace iTechArt.SchoolSchedule.DomainModel.People
{
    public class Teacher : Person
    {
        public ICollection<Lesson> Lessons { get; set; }
    }
}