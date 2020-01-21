using System.Collections.Generic;
using iTechArt.SchoolSchedule.DomainModel.Lessons;
using iTechArt.SchoolSchedule.DomainModel.People;

namespace iTechArt.SchoolSchedule.DomainModel.Grades
{
    public class Group : Entity
    {
        public string Name { get; set; }

        public int GradeId { get; set; }

        public Grade Grade { get; set; }

        public ICollection<PupilGroup> PupilGroups { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
    }
}