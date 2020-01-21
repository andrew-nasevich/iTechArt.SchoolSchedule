using System.Data.Entity.Migrations;

namespace iTechArt.SchoolSchedule.Repositories.Migrations
{   
    public partial class InitilCreate : DbMigration
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
                .PrimaryKey(t => t.Id);
            
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
                .Index(t => t.GradeId);
            
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
                .Index(t => t.LessonTimeId)
                .Index(t => t.TeacherId)
                .Index(t => t.ClassroomId)
                .Index(t => t.GradeId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Classrooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .Index(t => t.LessonId);
            
            CreateTable(
                "dbo.LessonTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DayOfWeek = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Patronymic = c.String(nullable: false),
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
                        Id = c.Int(nullable: false, identity: true),
                        PupilId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PupilId, cascadeDelete: true)
                .Index(t => t.PupilId)
                .Index(t => t.GroupId);
            
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
            DropIndex("dbo.PupilGroups", new[] { "GroupId" });
            DropIndex("dbo.PupilGroups", new[] { "PupilId" });
            DropIndex("dbo.People", new[] { "GradeId" });
            DropIndex("dbo.Homework", new[] { "LessonId" });
            DropIndex("dbo.Lessons", new[] { "GroupId" });
            DropIndex("dbo.Lessons", new[] { "GradeId" });
            DropIndex("dbo.Lessons", new[] { "ClassroomId" });
            DropIndex("dbo.Lessons", new[] { "TeacherId" });
            DropIndex("dbo.Lessons", new[] { "LessonTimeId" });
            DropIndex("dbo.Lessons", new[] { "CourseId" });
            DropIndex("dbo.Groups", new[] { "GradeId" });
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