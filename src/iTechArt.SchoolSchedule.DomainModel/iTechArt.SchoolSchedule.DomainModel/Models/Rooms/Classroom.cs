using iTechArt.SchoolSchedule.DomainModel.Models.Lessons;
using System.Collections.Generic;

namespace iTechArt.SchoolSchedule.DomainModel.Models.Rooms
{
    public class Classroom
    {
        public int Id { get; set; }

        public int RoomNumber { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
    }
}