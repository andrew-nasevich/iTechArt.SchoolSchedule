using System.Collections.Generic;
using iTechArt.SchoolSchedule.DomainModel.Models.Lessons;
using iTechArt.SchoolSchedule.DomainModel.Models.People;

namespace iTechArt.SchoolSchedule.DomainModel.Models.Grades
{
    public class Group
    {
        public int Id { get; set; }

        public string Category { get; set; }

        public ICollection<Pupil> Pupils { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
    }
}