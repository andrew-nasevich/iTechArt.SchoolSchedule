namespace iTechArt.SchoolSchedule.Repositories.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<iTechArt.SchoolSchedule.Repositories.DbContexts.SchoolScheduleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(iTechArt.SchoolSchedule.Repositories.DbContexts.SchoolScheduleContext context)
        {

        }
    }
}
