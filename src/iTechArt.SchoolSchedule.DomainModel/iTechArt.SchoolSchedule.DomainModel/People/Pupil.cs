using iTechArt.SchoolSchedule.DomainModel.Grades;
using System.Collections.Generic;

namespace iTechArt.SchoolSchedule.DomainModel.People
{
    public class Pupil : Person
    {
        public int GradeId { get; set; }

        public Grade Grade { get; set; }

        public ICollection<PupilGroup> PupilGroups { get; set; }
    }
}