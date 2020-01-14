using System.Collections.Generic;
using iTechArt.SchoolSchedule.DomainModel.Models.People;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace iTechArt.SchoolSchedule.DomainModel.Models.Grades
{
    public class Grade
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string Letter { get; set; }

        public IEnumerable<Pupil> Pupils { get; set; } 

        public IEnumerable<Group> Groups { get; set; }
    }
}