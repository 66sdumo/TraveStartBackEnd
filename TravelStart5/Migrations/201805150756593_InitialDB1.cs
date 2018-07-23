namespace TravelStart5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Password");
        }
    }
}
