namespace SoccerTrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rosters", "Jersey", c => c.Int(nullable: false));
            DropColumn("dbo.Rosters", "JerseyNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rosters", "JerseyNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Rosters", "Jersey");
        }
    }
}
