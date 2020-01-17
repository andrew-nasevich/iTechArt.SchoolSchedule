using iTechArt.SchoolSchedule.DomainModel.People;
using iTechArt.SchoolSchedule.DomainModel.Rooms;
using iTechArt.SchoolSchedule.DomainModel.Grades;
using System.Collections.Generic;

namespace iTechArt.SchoolSchedule.DomainModel.Lessons
{
    public class Lesson : Entity
    { 
        public int CourseId { get; set; }

        public Course Course { get; set; }

        public int LessonTimeId { get; set; }

        public LessonTime LessonTime { get; set; }

        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public int ClassroomId { get; set; }

        public Classroom Classroom { get; set; }

        public int GradeId { get; set; }

        public Grade Grade { get; set; }

        public int? GroupId { get; set; }

        public Group Group { get; set; }

        public ICollection<Homework> Homework { get; set; }
    }
}