using System.Collections.Generic;
using iTechArt.SchoolSchedule.DomainModel.Models.Grades;
using iTechArt.SchoolSchedule.DomainModel.Models.Lessons;

namespace iTechArt.SchoolSchedule.DomainModel.Models.People
{
    public class Pupil : Person
    {
        public int GradeId { get; set; }

        public Grade Grade { get; set; }

        public IEnumerable<Lesson> Lessons { get; set; }
    }
}