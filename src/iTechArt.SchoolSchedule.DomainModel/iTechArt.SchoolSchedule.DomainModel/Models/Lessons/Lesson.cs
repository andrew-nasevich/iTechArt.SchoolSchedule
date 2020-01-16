using System;
using iTechArt.SchoolSchedule.DomainModel.Models.People;
using iTechArt.SchoolSchedule.DomainModel.Models.Rooms;
using iTechArt.SchoolSchedule.DomainModel.Models.Grades;

namespace iTechArt.SchoolSchedule.DomainModel.Models.Lessons
{
    public class Lesson
    {
        public int Id { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public DateTime DateTime { get; set; }

        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public int ClassroomId { get; set; }

        public Classroom Classroom { get; set; }

        public int GradeId { get; set; }

        public Grade Grade { get; set; }

        public int? GroupId { get; set; }

        public Group Group { get; set; }

        public int? HomeWorkId { get; set; }

        public HomeWork HomeWork { get; set; }
    }
}