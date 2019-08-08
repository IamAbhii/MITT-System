namespace MITT_System_V1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationUserCourses", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserCourses", new[] { "ApplicationUser_Id" });
            RenameColumn(table: "dbo.ApplicationUserCourses", name: "Course_CourseId", newName: "CourseId");
            RenameIndex(table: "dbo.ApplicationUserCourses", name: "IX_Course_CourseId", newName: "IX_CourseId");
            DropPrimaryKey("dbo.ApplicationUserCourses");
            AddColumn("dbo.Courses", "Credits", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "DOB", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "Type", c => c.Int());
            AddColumn("dbo.ApplicationUserCourses", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ApplicationUserCourses", "ApplicationUserId", c => c.Int(nullable: false));
            AddColumn("dbo.ApplicationUserCourses", "DateOfJoin", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "IsOnVisa", c => c.Boolean());
            AlterColumn("dbo.ApplicationUserCourses", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.ApplicationUserCourses", "Id");
            CreateIndex("dbo.ApplicationUserCourses", "ApplicationUser_Id");
            AddForeignKey("dbo.ApplicationUserCourses", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserCourses", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserCourses", new[] { "ApplicationUser_Id" });
            DropPrimaryKey("dbo.ApplicationUserCourses");
            AlterColumn("dbo.ApplicationUserCourses", "ApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUsers", "IsOnVisa", c => c.Boolean(nullable: false));
            DropColumn("dbo.ApplicationUserCourses", "DateOfJoin");
            DropColumn("dbo.ApplicationUserCourses", "ApplicationUserId");
            DropColumn("dbo.ApplicationUserCourses", "Id");
            DropColumn("dbo.AspNetUsers", "Type");
            DropColumn("dbo.AspNetUsers", "DOB");
            DropColumn("dbo.Courses", "Credits");
            AddPrimaryKey("dbo.ApplicationUserCourses", new[] { "ApplicationUser_Id", "Course_CourseId" });
            RenameIndex(table: "dbo.ApplicationUserCourses", name: "IX_CourseId", newName: "IX_Course_CourseId");
            RenameColumn(table: "dbo.ApplicationUserCourses", name: "CourseId", newName: "Course_CourseId");
            CreateIndex("dbo.ApplicationUserCourses", "ApplicationUser_Id");
            AddForeignKey("dbo.ApplicationUserCourses", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
