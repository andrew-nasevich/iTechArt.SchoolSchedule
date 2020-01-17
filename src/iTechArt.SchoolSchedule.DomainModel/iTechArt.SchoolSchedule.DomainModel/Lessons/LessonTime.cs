using System;

namespace iTechArt.SchoolSchedule.DomainModel.Lessons
{
    public class LessonTime : Entity
    {
        public DayOfWeek DayOfWeek { get; set; }

        public int Order { get; set; }
    }
}