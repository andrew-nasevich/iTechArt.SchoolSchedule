using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using iTechArt.SchoolSchedule.DomainModel.Grades;
using iTechArt.SchoolSchedule.DomainModel.Lessons;
using iTechArt.SchoolSchedule.DomainModel.People;
using iTechArt.SchoolSchedule.DomainModel.Rooms;
using iTechArt.SchoolSchedule.Repositories.DbContexts;
using iTechArt.SchoolSchedule.Repositories.SchoolScheduleUnitOfWork;

namespace iTechArt.SchoolSchedule.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task<string> Index()
        {
            var context = new SchoolScheduleContext();
            var uow = new SchoolScheduleUnitOfWork(context);
            
            var gradeRep = uow.GetRepository<Grade>();
            var groupRep = uow.GetRepository<Group>();
            var pupilRep = uow.GetRepository<Pupil>();
            var lessonRep = uow.GetRepository<Lesson>();
            var teacherRep = uow.GetRepository<Teacher>();
            var classroomRep = uow.GetRepository<Classroom>();
            var courseRep = uow.GetRepository<Course>();
            var homeworkRep = uow.GetRepository<Homework>();
            var lessonTimeRep = uow.GetRepository<LessonTime>();


            /*var grade = new Grade{ Id = 1, Letter = "A", Number = GradeNumber.Eleventh };
            var address = new Address{ HouseNumber = "8", Street = "Bannaia" };
            var group = new Group { Grade = grade, Id = 1, Name = "OnePersonGroup", GradeId = grade.Id };
            var pupil = new Pupil
                { Address = address, Id = 1, Name = "Andrea", Patronymic = "Alexandrovich", Surname = "Nasevich", Grade = grade, GradeId = grade.Id };
            var pupilGroup = new PupilGroup { Group = group, GroupId = group.Id, Pupil = pupil, PupilId = pupil.Id };
            var teacher = new Teacher {Address = address, Id = 10, Name = "a", Patronymic = "a", Surname = "ASB"};
            var classroom = new Classroom {Id = 1, Name = "class"};
            var course = new Course { Id = 1, Name = "bio" };
            var lessonTime = new LessonTime{DayOfWeek = DayOfWeek.Friday, Id = 1, Order = LessonNumber.First};
            var lesson = new Lesson
            {
                Id = 1, Course = course, Grade = grade, GradeId = grade.Id, Group = group, GroupId = group.Id,
                Classroom = classroom, ClassroomId = classroom.Id, Teacher = teacher, CourseId = course.Id, LessonTime = lessonTime, LessonTimeId = lessonTime.Id, TeacherId = teacher.Id
            };
            var homework = new Homework{ DateTime = DateTime.Now, Id = 1, Description = "", Lesson = lesson, LessonId = lesson.Id};

            var lessonsList = new List<Lesson>{lesson};
            var groupsList = new List<Group> { group };
            var pupilsList = new List<Pupil> { pupil };
            var pupilGroupsList = new List<PupilGroup> { pupilGroup };
            var homeworksList = new List<Homework> {homework};

            grade.Groups = groupsList;
            grade.Pupils = pupilsList;
            grade.Lessons = lessonsList;

            group.PupilGroups = pupilGroupsList;
            group.Lessons = lessonsList;
            pupil.PupilGroups = pupilGroupsList;
            teacher.Lessons = lessonsList;
            classroom.Lessons = lessonsList;
            course.Lessons = lessonsList;
            lessonTime.Lessons = lessonsList;
            lesson.Homeworks = homeworksList;

            gradeRep.Add(grade);
            groupRep.Add(group);
            pupilRep.Add(pupil);
            lessonRep.Add(lesson);
            classroomRep.Add(classroom);
            teacherRep.Add(teacher);
            courseRep.Add(course);
            homeworkRep.Add(homework);
            lessonTimeRep.Add(lessonTime);*/

            context.SaveChanges();

            var p = context.Set<Pupil>().Include("PupilGroups").FirstOrDefault();
            
            pupilRep.Remove(p);
       
            context.SaveChanges();
            return "Hello, World!";
        }
    }
}