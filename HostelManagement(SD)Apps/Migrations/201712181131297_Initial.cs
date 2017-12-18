namespace HostelManagement_SD_Apps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BloodGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DeptmentId = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
                        ContactNo = c.String(),
                        Email = c.String(),
                        BloodGroupId = c.Int(nullable: false),
                        District = c.String(),
                        Thana = c.String(),
                        Department_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BloodGroups", t => t.BloodGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.Department_Id)
                .ForeignKey("dbo.Semesters", t => t.SemesterId, cascadeDelete: true)
                .Index(t => t.SemesterId)
                .Index(t => t.BloodGroupId)
                .Index(t => t.Department_Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Students", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.Students", "BloodGroupId", "dbo.BloodGroups");
            DropIndex("dbo.Students", new[] { "Department_Id" });
            DropIndex("dbo.Students", new[] { "BloodGroupId" });
            DropIndex("dbo.Students", new[] { "SemesterId" });
            DropTable("dbo.Departments");
            DropTable("dbo.Students");
            DropTable("dbo.Semesters");
            DropTable("dbo.BloodGroups");
        }
    }
}
