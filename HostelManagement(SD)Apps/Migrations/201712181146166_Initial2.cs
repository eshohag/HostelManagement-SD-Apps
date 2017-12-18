namespace HostelManagement_SD_Apps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Department_Id", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "Department_Id" });
            RenameColumn(table: "dbo.Students", name: "Department_Id", newName: "DepartmentId");
            AlterColumn("dbo.Students", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "DepartmentId");
            AddForeignKey("dbo.Students", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
            DropColumn("dbo.Students", "DeptmentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "DeptmentId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            AlterColumn("dbo.Students", "DepartmentId", c => c.Int());
            RenameColumn(table: "dbo.Students", name: "DepartmentId", newName: "Department_Id");
            CreateIndex("dbo.Students", "Department_Id");
            AddForeignKey("dbo.Students", "Department_Id", "dbo.Departments", "Id");
        }
    }
}
