namespace SoccerTrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMigration2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rosters", "Saves");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rosters", "Saves", c => c.Int(nullable: false));
        }
    }
}
