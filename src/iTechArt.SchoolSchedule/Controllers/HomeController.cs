using iTechArt.SchoolSchedule.DomainModel.Models.People;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;

namespace iTechArt.SchoolSchedule.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            var context = new MyContext();
            var p =  new Person() { Id = 1, Name = "Andrew", Patronymic = "Al", Surname = "Nasevich" };

            context.Persons.Add(p);
            context.SaveChanges();

            return "Hello, World!";
        }
    }

    public class MyContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
    }
}