using iTechArt.SchoolSchedule.DomainModel.Models.Grades;

namespace iTechArt.SchoolSchedule.DomainModel.Models.People
{
    public class Pupil : Person
    {
        public int GradeId { get; set; }

        public Grade Grade { get; set; }
    }
}