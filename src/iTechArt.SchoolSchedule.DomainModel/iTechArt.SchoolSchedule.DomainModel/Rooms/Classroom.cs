using iTechArt.SchoolSchedule.DomainModel.Lessons;
using System.Collections.Generic;

namespace iTechArt.SchoolSchedule.DomainModel.Rooms
{
    public class Classroom : Entity
    {
        public string Name { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
    }
}