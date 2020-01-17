using iTechArt.SchoolSchedule.DomainModel.Grades;

namespace iTechArt.SchoolSchedule.DomainModel.People
{
    public class Pupil : Person
    {
        public int GradeId { get; set; }

        public Grade Grade { get; set; }
    }
}