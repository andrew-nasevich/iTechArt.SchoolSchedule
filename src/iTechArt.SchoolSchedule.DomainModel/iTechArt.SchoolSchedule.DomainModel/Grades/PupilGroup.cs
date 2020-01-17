using iTechArt.SchoolSchedule.DomainModel.People;

namespace iTechArt.SchoolSchedule.DomainModel.Grades
{
    public class PupilGroup : Entity
    {
        public int PupilId { get; set; }

        public Pupil Pupil { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }
    }
}