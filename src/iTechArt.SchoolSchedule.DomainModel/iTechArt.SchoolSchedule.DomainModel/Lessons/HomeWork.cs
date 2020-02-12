using System;

namespace iTechArt.SchoolSchedule.DomainModel.Lessons
{
    public class Homework : Entity
    {
        public string Description { get; set; }

        public DateTime DateTime { get; set; }

        public int LessonId { get; set; }
        
        public Lesson Lesson { get; set; }
    }
}