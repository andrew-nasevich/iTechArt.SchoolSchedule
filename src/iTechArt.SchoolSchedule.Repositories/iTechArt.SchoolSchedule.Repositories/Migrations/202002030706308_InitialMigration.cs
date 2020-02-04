namespace iTechArt.SchoolSchedule.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Letter = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.Number, t.Letter }, unique: true);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        GradeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grades", t => t.GradeId, cascadeDelete: true)
                .Index(t => new { t.Name, t.GradeId }, unique: true);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        LessonTimeId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        ClassroomId = c.Int(nullable: false),
                        GradeId = c.Int(nullable: false),
                        GroupId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classrooms", t => t.ClassroomId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Grades", t => t.GradeId, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.GroupId)
                .ForeignKey("dbo.LessonTimes", t => t.LessonTimeId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => new { t.ClassroomId, t.LessonTimeId, t.TeacherId }, unique: true)
                .Index(t => t.GradeId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Classrooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.RoomName, unique: true);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Homework",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        LessonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lessons", t => t.LessonId, cascadeDelete: true)
                .Index(t => new { t.DateTime, t.LessonId }, unique: true);
            
            CreateTable(
                "dbo.LessonTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DayOfWeek = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.DayOfWeek, t.Order }, unique: true);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Patronymic = c.String(nullable: false),
                        Address_Street = c.String(),
                        Address_HouseNumber = c.String(),
                        GradeId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grades", t => t.GradeId, cascadeDelete: true)
                .Index(t => t.GradeId);
            
            CreateTable(
                "dbo.PupilGroups",
                c => new
                    {
                        GroupId = c.Int(nullable: false),
                        PupilId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GroupId, t.PupilId })
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PupilId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.PupilId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PupilGroups", "PupilId", "dbo.People");
            DropForeignKey("dbo.People", "GradeId", "dbo.Grades");
            DropForeignKey("dbo.PupilGroups", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Lessons", "TeacherId", "dbo.People");
            DropForeignKey("dbo.Lessons", "LessonTimeId", "dbo.LessonTimes");
            DropForeignKey("dbo.Homework", "LessonId", "dbo.Lessons");
            DropForeignKey("dbo.Lessons", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Lessons", "GradeId", "dbo.Grades");
            DropForeignKey("dbo.Lessons", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Lessons", "ClassroomId", "dbo.Classrooms");
            DropForeignKey("dbo.Groups", "GradeId", "dbo.Grades");
            DropIndex("dbo.PupilGroups", new[] { "PupilId" });
            DropIndex("dbo.PupilGroups", new[] { "GroupId" });
            DropIndex("dbo.People", new[] { "GradeId" });
            DropIndex("dbo.LessonTimes", new[] { "DayOfWeek", "Order" });
            DropIndex("dbo.Homework", new[] { "DateTime", "LessonId" });
            DropIndex("dbo.Courses", new[] { "Name" });
            DropIndex("dbo.Classrooms", new[] { "RoomName" });
            DropIndex("dbo.Lessons", new[] { "GroupId" });
            DropIndex("dbo.Lessons", new[] { "GradeId" });
            DropIndex("dbo.Lessons", new[] { "ClassroomId", "LessonTimeId", "TeacherId" });
            DropIndex("dbo.Lessons", new[] { "CourseId" });
            DropIndex("dbo.Groups", new[] { "Name", "GradeId" });
            DropIndex("dbo.Grades", new[] { "Number", "Letter" });
            DropTable("dbo.PupilGroups");
            DropTable("dbo.People");
            DropTable("dbo.LessonTimes");
            DropTable("dbo.Homework");
            DropTable("dbo.Courses");
            DropTable("dbo.Classrooms");
            DropTable("dbo.Lessons");
            DropTable("dbo.Groups");
            DropTable("dbo.Grades");
        }
    }
}
