using System;
using System.Collections.Generic;

namespace iTechArt.SchoolSchedule.DomainModel.Lessons
{
    public class LessonTime : Entity
    {
        public DayOfWeek DayOfWeek { get; set; }

        public LessonNumber Order { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
    }
}