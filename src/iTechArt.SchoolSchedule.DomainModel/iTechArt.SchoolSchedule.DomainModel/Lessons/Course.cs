using System.Collections.Generic;

namespace iTechArt.SchoolSchedule.DomainModel.Lessons
{
    public class Course : Entity
    {
        public string Name { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
    }
}