using System.Data.Entity.Migrations;

namespace iTechArt.SchoolSchedule.Repositories.Migrations
{
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                        Patronymic = c.String(nullable: false, maxLength: 50),
                        Street = c.String(nullable: false, maxLength: 50),
                        HouseNumber = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.CourseId)
                .Index(t => new { t.ClassroomId, t.LessonTimeId, t.TeacherId }, unique: true)
                .Index(t => t.GradeId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Classrooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Letter = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.Number, t.Letter }, unique: true);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        GradeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grades", t => t.GradeId, cascadeDelete: true)
                .Index(t => new { t.Name, t.GradeId }, unique: true);
            
            CreateTable(
                "dbo.PupilGroups",
                c => new
                    {
                        GroupId = c.Int(nullable: false),
                        PupilId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GroupId, t.PupilId })
                .ForeignKey("dbo.Groups", t => t.GroupId)
                .ForeignKey("dbo.Pupils", t => t.PupilId)
                .Index(t => t.GroupId)
                .Index(t => t.PupilId);
            
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
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Pupils",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        GradeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Id)
                .ForeignKey("dbo.Grades", t => t.GradeId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.GradeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pupils", "GradeId", "dbo.Grades");
            DropForeignKey("dbo.Pupils", "Id", "dbo.People");
            DropForeignKey("dbo.Teachers", "Id", "dbo.People");
            DropForeignKey("dbo.Lessons", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Lessons", "LessonTimeId", "dbo.LessonTimes");
            DropForeignKey("dbo.Homework", "LessonId", "dbo.Lessons");
            DropForeignKey("dbo.Lessons", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Lessons", "GradeId", "dbo.Grades");
            DropForeignKey("dbo.PupilGroups", "PupilId", "dbo.Pupils");
            DropForeignKey("dbo.PupilGroups", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Groups", "GradeId", "dbo.Grades");
            DropForeignKey("dbo.Lessons", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Lessons", "ClassroomId", "dbo.Classrooms");
            DropIndex("dbo.Pupils", new[] { "GradeId" });
            DropIndex("dbo.Pupils", new[] { "Id" });
            DropIndex("dbo.Teachers", new[] { "Id" });
            DropIndex("dbo.LessonTimes", new[] { "DayOfWeek", "Order" });
            DropIndex("dbo.Homework", new[] { "DateTime", "LessonId" });
            DropIndex("dbo.PupilGroups", new[] { "PupilId" });
            DropIndex("dbo.PupilGroups", new[] { "GroupId" });
            DropIndex("dbo.Groups", new[] { "Name", "GradeId" });
            DropIndex("dbo.Grades", new[] { "Number", "Letter" });
            DropIndex("dbo.Courses", new[] { "Name" });
            DropIndex("dbo.Classrooms", new[] { "Name" });
            DropIndex("dbo.Lessons", new[] { "GroupId" });
            DropIndex("dbo.Lessons", new[] { "GradeId" });
            DropIndex("dbo.Lessons", new[] { "ClassroomId", "LessonTimeId", "TeacherId" });
            DropIndex("dbo.Lessons", new[] { "CourseId" });
            DropTable("dbo.Pupils");
            DropTable("dbo.Teachers");
            DropTable("dbo.LessonTimes");
            DropTable("dbo.Homework");
            DropTable("dbo.PupilGroups");
            DropTable("dbo.Groups");
            DropTable("dbo.Grades");
            DropTable("dbo.Courses");
            DropTable("dbo.Classrooms");
            DropTable("dbo.Lessons");
            DropTable("dbo.People");
        }
    }
}