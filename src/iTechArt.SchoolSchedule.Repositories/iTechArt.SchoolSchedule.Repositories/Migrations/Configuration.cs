﻿using System.Data.Entity.Migrations;
using iTechArt.SchoolSchedule.Repositories.DbContexts;

namespace iTechArt.SchoolSchedule.Repositories.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SchoolScheduleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }


        protected override void Seed(SchoolScheduleContext context)
        {

        }
    }
}