namespace iTechArt.SchoolSchedule.DomainModel.Models.Lessons
{
    public class HomeWork
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int LessonId { get; set; }
        
        public Lesson Lesson { get; set; }
    }
}