using System.Collections.Generic;
using iTechArt.SchoolSchedule.DomainModel.Lessons;
using iTechArt.SchoolSchedule.DomainModel.People;

namespace iTechArt.SchoolSchedule.DomainModel.Grades
{
    public class Grade : Entity
    {
        public GradeNumber Number { get; set; }

        public string Letter { get; set; }

        public ICollection<Pupil> Pupils { get; set; } 

        public ICollection<Group> Groups { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
    }
}