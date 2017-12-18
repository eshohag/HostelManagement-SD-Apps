namespace HostelManagement_SD_Apps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "StudentID", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "ContactNo", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "District", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Thana", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Thana", c => c.String());
            AlterColumn("dbo.Students", "District", c => c.String());
            AlterColumn("dbo.Students", "ContactNo", c => c.String());
            AlterColumn("dbo.Students", "Name", c => c.String());
            AlterColumn("dbo.Students", "StudentID", c => c.String());
        }
    }
}
