namespace TravelStart5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDefualtColumnNames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Lname", c => c.String());
            AddColumn("dbo.User", "Fname", c => c.String());
            AddColumn("dbo.User", "Title", c => c.String());
            AddColumn("dbo.User", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Password");
            DropColumn("dbo.User", "Title");
            DropColumn("dbo.User", "Fname");
            DropColumn("dbo.User", "Lname");
        }
    }
}
