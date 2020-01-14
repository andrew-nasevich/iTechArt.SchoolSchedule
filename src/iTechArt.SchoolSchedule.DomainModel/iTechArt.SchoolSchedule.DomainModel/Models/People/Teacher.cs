using System.Collections.Generic;
using iTechArt.SchoolSchedule.DomainModel.Models.Lessons;

namespace iTechArt.SchoolSchedule.DomainModel.Models.People
{
    public class Teacher : Person
    {
        public ICollection<Lesson> Schedule { get; set; }
    }
}