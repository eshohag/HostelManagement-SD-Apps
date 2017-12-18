namespace HostelManagement_SD_Apps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "StudentID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "StudentID");
        }
    }
}
